using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SignBirdID.Controllers;
using SignBirdID.Models;


namespace SignBirdID
{
    public partial class frmPrincipal : Form
    {
        SignService signService = new SignService();
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            Connection superConn = new Connection();

            string value = superConn.ReadConfiguration();
            if (!value.Equals("erro"))
            {
                try
                {
                    superConn.Connect(@value);
                    //Verificar se token esta expirado
                    //se sim solicitar novo | se não pular para assinatura.

                   // var signInfo = signService.GetSignDigitalInfoByDocument(superConn.conn, "94883911039");
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

        private void button1_Click(object sender, EventArgs e)
        {
        }


    }
}
