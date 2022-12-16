using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        public string SuperJson { get; set; } = string.Empty;

        bool IsEdit = false;

        public int DiddyReturn { get; set; } = 0;
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
                    SignLog.CreateLog("Conectou com o banco de dados.");

                    signInfo = signService.GetSignDigitalInfoByDocument(superConn.conn, Params[0]);
                    SignLog.CreateLog("Buscou informações de autenticação do certificado.");
                    //Existe registro sigo em frente
                    if (signInfo != null)
                    {
                        superConn.conn.Close();
                        if(signInfo.ExpirationDate > DateTime.Now)
                        {
                            //Data na validade vou assinar
                            SignLog.CreateLog("Autenticação dentro da data de validade.");
                            this.Hide();
                            var dialog = new FrmSigningProcess(signInfo,Params);
                            dialog.ShowDialog();
                            DiddyReturn = dialog.DiddyReturn;
                            this.Close();
                        }
                        else
                        {
                            IsEdit = true;
                            SignLog.CreateLog("Autenticação expirou.");
                            //Data expirou vou atualizar
                            //Exibir formulario
                        }

                    }
                    else
                    {
                        SignLog.CreateLog("Nenhuma autenticação encontrada, processo de criação iniciado");
                        signInfo = new SignDigitalInfo();
                        IsEdit = false;
                        //Nenhum registro encontrado vou criar
                        //Exibir formulario
                    }
                }
                catch (Exception ex)
                {
                    SignLog.CreateLog($"Falha ao conectar Banco de dados! | {ex.Message}");
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

        private async void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTokenOTP.Text))
                return;

            if (!File.Exists(Params[2]))
            {
                MessageBox.Show("O Arquivo: \n" + Params[2] + "\n Não Existe! Favor Verificar origem.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnOK.Enabled = false;
            pbxLoadToken.Visible = true; ;
            try
            {
                var json = string.Empty;
                await CallAuthorize();
                 
                SignLog.CreateLog("Metodo Authorize executado");

                if (!json.Equals("erro"))
                {
                    superConn.Connect(configuration.connectionString);
                    ResponseAPI.Authorize authorize = JsonConvert.DeserializeObject<ResponseAPI.Authorize>(SuperJson);

                    if (IsEdit)
                    {
                        signInfo.Authorization = authorize.authorization;
                        signInfo.AccessNumber = authorize.access_token;
                        signInfo.ExpirationDate = DateTime.Now.AddHours(12);

                        //Atualizo valores no banco
                        signService.UpdateSignDigitalInfo(superConn.conn, signInfo);
                        SignLog.CreateLog("Autenticação atualizada.");

                    }
                    else
                    {
                        signInfo.Document = Params[0];
                        signInfo.ClientSecret = configuration.clientsecret;
                        signInfo.ClientID = configuration.clientid;
                        signInfo.Authorization = authorize.authorization;
                        signInfo.AccessNumber = authorize.access_token;
                        signInfo.ExpirationDate = DateTime.Now.AddHours(12);

                        //crio um novo registro
                        var id = signService.CreateSignDigitalInfo(superConn.conn, signInfo);
                        SignLog.CreateLog("Nova autenticação criada.");
                    }

                    this.Hide();
                    var dialog = new FrmSigningProcess(signInfo,Params);
                    dialog.ShowDialog();
                    DiddyReturn = dialog.DiddyReturn;
                    this.Close();
                }
                else
                {
                    SignLog.CreateLog("Falha ao tentar autenticar.");
                    MessageBox.Show("Falha ao tentar autenticar.");
                }
            }
            catch (Exception ex)
            {
                SignLog.CreateLog("Falha ao tentar autenticar: " + ex.Message);
                MessageBox.Show("Falha ao tentar autenticar.");
                
            }

            pbxLoadToken.Visible = false;
            txtTokenOTP.Clear();
            btnOK.Enabled = true;
        }

        public async Task CallAuthorize()
        {
            await Task.Run(() => Authorize());
        }
        public void Authorize()
        {
           SuperJson = SignAPI.Authorize(configuration, txtTokenOTP.Text.Trim(), Params[0]);
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
