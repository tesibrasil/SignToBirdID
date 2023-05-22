
using Essy.Tools.InputBox;
using Newtonsoft.Json;
using SignBirdID.Controllers;
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
using System.Xml.Linq;


namespace SignBirdID.Views
{
    public partial class FrmSigningProcess : Form
    {

        SignService signService = new SignService();
        Connection superConn = new Connection();
        SignDigitalInfo digitalInfoValidation;
        SignDigitalInfo digitalInfo;
        string[] Params = null;
        Configuration configuration = new Configuration();
        SignReturn r = new SignReturn();
        bool forcedPosition;
        bool notShow;
        public int DiddyReturn { get; set; } = 0;

        bool stopApp;
        public FrmSigningProcess(SignDigitalInfo signInfo = null, string[] args = null)
        {
            InitializeComponent();
            digitalInfo = signInfo;
            Params = args;
            tmpSign.Enabled = true;
            forcedPosition = false;
            stopApp = false;
            notShow = false;


        }


        private void pbxLoad_DoubleClick(object sender, EventArgs e)
        {
            Close();
        }

        private async void tmpSign_TickAsync(object sender, EventArgs e)
        {
            tmpSign.Enabled = false;

            if (Params.Length == 3)
            {

                if (!File.Exists(Params[2]))
                {
                    SignLog.CreateLog("O arquivo não existe " + Params[2]);
                    MessageBox.Show("O Arquivo: \n" + Params[2] + "\n Não Existe! Favor Verificar origem.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tmpClose.Enabled = true;
                    return;
                }
            }

            SignLog.CreateLog("Iniciado processo de assinatura");

            await CallProcessAsync();

            if (stopApp)
            {
                Close();
            }

            if (!r.HasError)
            {
                lblMessage.ForeColor = Color.Green;
                pbxLoad.Visible = false;
                pbxOk.Visible = true;
                if (Params.Length == 2)
                {
                    SignLog.CreateLog("Assinatura realizada |  Exame:" + Params[0] + " Arquivo:" + Params[1]);
                }
                else
                {
                    SignLog.CreateLog("Assinatura realizada | cerificado:" + Params[0] + " Exame:" + Params[1] + " Arquivo:" + Params[2]);
                }
                if (notShow)
                {
                    DiddyReturn = 0;
                }
                else
                {
                    DiddyReturn = 1;
                }
            }
            else
            {
                lblMessage.ForeColor = Color.Red;
                pbxLoad.Visible = false;
                pbxErro.Visible = true;
                if (Params.Length == 2)
                {
                    SignLog.CreateLog("Falha Assinatura |  Exame:" + Params[0] + " Arquivo:" + Params[1]);
                }
                else
                {
                    SignLog.CreateLog("Falha Assinatura | cerificado:" + Params[0] + " Exame:" + Params[1] + " Arquivo:" + Params[2]);
                }
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

            //verificar a possibilidade de uma segunda assinatura
            superConn.Connect(@configuration.connectionString);

            if (Params.Length == 3)
            {
                digitalInfoValidation = signService.GetSignDigitalInfoValidationByExamId(superConn.conn, Params[1]);
            }
            else
            {
                digitalInfoValidation = signService.GetSignDigitalInfoValidationByExamId(superConn.conn, Params[0]);
            }
            //digitalInfoValidation = signService.GetSignDigitalInfoByDocument(superConn.conn, "94883911039");
            superConn.conn.Close();

            if (digitalInfoValidation != null && digitalInfoValidation.Document != "")
            {
                if(Params.Length == 2)
                {

                    digitalInfoValidation.Axle = "385:680";
                    string [] newParams = { "", Params[0], Params[1] };
                    Assignature(configuration, digitalInfoValidation, newParams);

                    DiddyReturn = 0;
                    stopApp = true;
                    return;

                }
                else
                if (digitalInfo.Document != digitalInfoValidation.Document && digitalInfoValidation.ExpirationDate > DateTime.Now)
                {
                    //possui duas assinaturas
                    SignLog.CreateLog("Possui duas asssinaturas.");

                    digitalInfoValidation.Axle = "165:680";

                    Assignature(configuration, digitalInfoValidation, Params);

                }
                else
                {

                    SignLog.CreateLog("Token do primeiro assinante expirado.");
                    var r = MessageBox.Show($"Token da assinatura anterior expirado.\n Solicite ao profissional que validou o exame\n a renovação, ou clique em 'YES' para inserir somente sua assinatura.", "Erro", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                   
                    if (r == DialogResult.No)
                    {
                        notShow = true;
                        stopApp = true;
                        return;
                    }
                }
            }
            else
            {


                if (digitalInfoValidation != null && digitalInfoValidation.ExpirationDate < DateTime.Now)
                {

                    SignLog.CreateLog("Token do primeiro assinante expirado.");
                    var r =  MessageBox.Show($"Token da assinatura anterior expirado.\n Solicite ao profissional que validou o exame\n a renovação, ou clique em 'YES' para inserir somente sua assinatura.", "Erro", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (r == DialogResult.No)
                    {
                        notShow = true;
                        stopApp = true;
                        return;
                    }
                }
               


            }

            //Assinatura principal
            if (forcedPosition)
            {
                digitalInfo.Axle = "385:680";
            }

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

        public void Assignature(Configuration configuration, SignDigitalInfo signDigitalInfo, string[] parameters)
        {
            string jsonV = SignAPI.Signature(configuration, signDigitalInfo, parameters);

            if (!jsonV.Equals("erro"))
            {
                SignLog.CreateLog("Primeira asssinatura.");

                ResponseAPI.Signature signature = JsonConvert.DeserializeObject<ResponseAPI.Signature>(jsonV);

                string json2V = SignAPI.GetDownloadURL(configuration, signature.tcn, signDigitalInfo);

                if (!json2V.Equals("erro"))
                {
                    ResponseAPI.GetDownloadURL getDownloadURL = JsonConvert.DeserializeObject<ResponseAPI.GetDownloadURL>(json2V);
                    //efetuar downolad do arquivo
                    var wc = new WebClient();

                    while (getDownloadURL.documents[0].status.Equals("WAITING") && getDownloadURL.documents[0].result == null)
                    {
                        json2V = SignAPI.GetDownloadURL(configuration, signature.tcn, signDigitalInfo);
                        getDownloadURL = JsonConvert.DeserializeObject<ResponseAPI.GetDownloadURL>(json2V);
                    }

                    wc.DownloadFile(getDownloadURL.documents[0].result, parameters[2]);

                    r.Message = "Documento Assinado";

                    SignLog.CreateLog("Download da primeira assinatura concluído em: " + parameters[2]);

                    forcedPosition = true;

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
