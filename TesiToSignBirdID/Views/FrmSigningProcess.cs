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

        private void tmpSign_TickAsync(object sender, EventArgs e)
        {
            tmpSign.Enabled = false;

            var th = new Thread(Process);
            th.Start();

            while (th.IsAlive)
            {
                //aguarda final da thread
            }

            if (!r.HasError)
            {
                lblMessage.ForeColor = Color.Green;
                pbxLoad.Visible = false;
                pbxOk.Visible = true;
            }
            else
            {
                lblMessage.ForeColor = Color.Red;
                pbxLoad.Visible = false;
                pbxErro.Visible = true;
            }

            lblMessage.Text = r.Message;

            tmpClose.Enabled = true;
        }

        public void Process()
        {
            configuration = configuration.ReadConfiguration();
            string json = SignAPI.Signature(configuration, digitalInfo, Params);

            if (!json.Equals("erro"))
            {
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

                }
                else
                {
                    r.HasError = true;
                    r.Message = "Falha ao efetuar Download.";
                }

            }
            else
            {
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
