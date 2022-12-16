using Newtonsoft.Json;
using SignBirdID.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SignBirdID.Views
{
    public partial class FrmSigningProcess : Form
    {
        SignDigitalInfo digitalInfo;
        string[] Params = null;
        Configuration configuration = new Configuration();
        SignReturn r = new SignReturn();
        public int DiddyReturn { get; set; } = 0;
        public FrmSigningProcess(SignDigitalInfo signInfo = null, string[] args = null)
        {
            InitializeComponent();
            digitalInfo = signInfo;
            Params = args;
            tmpSign.Enabled = true;

        }


        private void pbxLoad_DoubleClick(object sender, EventArgs e)
        {
            Close();
        }

        private async void tmpSign_TickAsync(object sender, EventArgs e)
        {
            tmpSign.Enabled = false;

            if (!File.Exists(Params[2]))
            {
                SignLog.CreateLog("O arquivo não existe " + Params[2]);
                MessageBox.Show("O Arquivo: \n" + Params[2] + "\n Não Existe! Favor Verificar origem.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tmpClose.Enabled = true;
                return;
            }

            SignLog.CreateLog("Iniciado processo de assinatura");

            await CallProcessAsync();

            //while (!pro.IsCompleted)
            //{
            //    //aguarda final da thread
            //}

            if (!r.HasError)
            {
                lblMessage.ForeColor = Color.Green;
                pbxLoad.Visible = false;
                pbxOk.Visible = true;
                SignLog.CreateLog("Assinatura realizada | cerificado:" + Params[0] + " Exame:" + Params[1] + " Arquivo:" + Params[2]);
                DiddyReturn = 1;
            }
            else
            {
                lblMessage.ForeColor = Color.Red;
                pbxLoad.Visible = false;
                pbxErro.Visible = true;
                SignLog.CreateLog("Falha na assinatura | cerificado:" + Params[0] + " Exame:" + Params[1] + " Arquivo:" + Params[2]);
                DiddyReturn = 0;
            }

            lblMessage.Text = r.Message;

            tmpClose.Enabled = true;
        }

        public async Task CallProcessAsync()
        {
            await Task.Run(() => Process());
        }
        public void Process()
        {
            configuration = configuration.ReadConfiguration();
            
            string json = SignAPI.Signature(configuration, digitalInfo, Params);
            
            if (!json.Equals("erro"))
            {
                SignLog.CreateLog("Documento assinado.");

                ResponseAPI.Signature signature = JsonConvert.DeserializeObject<ResponseAPI.Signature>(json);

                string json2 = SignAPI.GetDownloadURL(configuration, signature.tcn, digitalInfo);

                if (!json2.Equals("erro"))
                {
                    ResponseAPI.GetDownloadURL getDownloadURL = JsonConvert.DeserializeObject<ResponseAPI.GetDownloadURL>(json2);
                    //efetuar downolad do arquivo
                    var wc = new WebClient();

                    while (getDownloadURL.documents[0].status.Equals("WAITING") && getDownloadURL.documents[0].result == null)
                    {
                        json2 = SignAPI.GetDownloadURL(configuration, signature.tcn, digitalInfo);
                        getDownloadURL = JsonConvert.DeserializeObject<ResponseAPI.GetDownloadURL>(json2);
                    }

                    wc.DownloadFile(getDownloadURL.documents[0].result, Params[2]);

                    r.Message = "Documento Assinado";

                    SignLog.CreateLog("Download concluído em: " + Params[2]);

                }
                else
                {
                    SignLog.CreateLog("Falha ao buscar URL para download do arquivo.");
                    r.HasError = true;
                    r.Message = "Falha ao efetuar Download.";
                }

            }
            else
            {
                SignLog.CreateLog("Falha no processo de assinatura");

                lblMessage.ForeColor = Color.Red;
                r.HasError = true;
                r.Message = "Falha ao assinar arquivo.";
            }



        }

        private void tmpClose_Tick(object sender, EventArgs e)
        {
            tmpClose.Enabled = false;
           
            Close();
        }
    }
}
