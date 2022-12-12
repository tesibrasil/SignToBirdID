using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SignBirdID.Controllers;
using SignBirdID.Models;
using SignBirdID.Views;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace SignBirdID
{
    public partial class frmPrincipal : Form
    {
        SignService signService = new SignService();
        
        Connection superConn = new Connection();

        Configuration configuration = new Configuration();

        SignDigitalInfo signInfo = new SignDigitalInfo();

        bool IsEdit = false;

        public string [] Params { get; set; }
        public frmPrincipal(string [] args)
        {
            Params = args;
            InitializeComponent();

        }

        private void Principal_Load(object sender, EventArgs e)
        {
            txtTokenOTP.Select();
           
            configuration = configuration.ReadConfiguration();
            
            if(configuration!= null)
            {
                try
                {
                    superConn.Connect(@configuration.connectionString);
                    //Verificar se token esta expirado
                    //se sim solicitar novo | se não pular para assinatura.
                    
                    signInfo = signService.GetSignDigitalInfoByDocument(superConn.conn, Params[0]);

                    //Existe registro sigo em frente
                    if(signInfo != null)
                    {
                        if(signInfo.ExpirationDate > DateTime.Now)
                        {
                            //Data na validade vou assinar
                            this.Hide();
                            var dialog = new FrmSigningProcess(signInfo,Params);
                            dialog.ShowDialog();
                            this.Close();
                        }
                        else
                        {
                            IsEdit = true;
                            //Data expirou vou atualizar
                            //Exibir formulario
                        }

                    }
                    else
                    {
                        signInfo = new SignDigitalInfo();
                        IsEdit = false;
                        //Nenhum registro encontrado vou criar
                        //Exibir formulario
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show($"Falha ao conectar Banco de Dados!\n {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }

            }
            else
            {
                Close();
            }


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();

        }



        private void txtTokenOTP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))

            {

                e.Handled = true;
            }

          
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTokenOTP.Text))
                return;

            var json = SignAPI.Authorize(configuration, txtTokenOTP.Text.Trim(), Params[0]);
            
            if (!json.Equals("erro"))
            {
                superConn.Connect(configuration.connectionString);
                ResponseAPI.Authorize authorize = JsonConvert.DeserializeObject<ResponseAPI.Authorize>(json);

                if (IsEdit)
                {
                    signInfo.Authorization = authorize.authorization;
                    signInfo.AccessNumber = authorize.access_token;
                    signInfo.ExpirationDate = DateTime.Now.AddHours(12);

                    //Atualizo valores no banco
                    signService.UpdateSignDigitalInfo(superConn.conn, signInfo);

                } 
                else 
                {
                    signInfo.Document = Params[0];
                    signInfo.ClientSecret = configuration.clientsecret;
                    signInfo.ClientID= configuration.clientid;
                    signInfo.Authorization = authorize.authorization;
                    signInfo.AccessNumber = authorize.access_token;
                    signInfo.ExpirationDate = DateTime.Now.AddHours(12);

                    //crio um novo registro
                    var id = signService.CreateSignDigitalInfo(superConn.conn, signInfo);
                }

                this.Hide();
                var dialog = new FrmSigningProcess(signInfo);
                dialog.ShowDialog();
                this.Close();
            }
            else
            {
                txtTokenOTP.Clear();
            }
        }

        private void txtTokenOTP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOK_Click(sender, e);
            }
        }
    }
}
