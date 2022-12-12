using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using SignBirdID.Controllers;
using SignBirdID.Models;
using SignBirdID.Views;


namespace SignBirdID
{
    public partial class frmPrincipal : Form
    {
        SignService signService = new SignService();
        public string [] Params { get; set; }
        public frmPrincipal(string [] args)
        {
            Params = args;
            InitializeComponent();

        }

        private void Principal_Load(object sender, EventArgs e)
        {
            txtTokenOTP.Select();
            Connection superConn = new Connection();

            Configuration configuration = new Configuration();
           
            configuration = configuration.ReadConfiguration();
            
            if(configuration!= null)
            {
                try
                {
                    superConn.Connect(@configuration.connectionString);
                    //Verificar se token esta expirado
                    //se sim solicitar novo | se não pular para assinatura.
                    
                    var signInfo = signService.GetSignDigitalInfoByDocument(superConn.conn, Params[0]);

                    if(signInfo != null)
                    {
                        if(signInfo.ExpirationDate < DateTime.Now)
                        {
                            //update
                        }
                        

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
            this.Hide();
            var dialog = new FrmSigningProcess();
            dialog.ShowDialog();
            this.Show();
        }
    }
}
