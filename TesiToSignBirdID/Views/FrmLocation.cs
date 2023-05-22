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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SignBirdID.Views
{
    public partial class frmLocation : Form
    {
        SignService signService = new SignService();
        public SignDigitalInfo SignInfo { get; set; }
        public string Axle { get; set; }

        Connection superConn = new Connection();

        Configuration configuration = new Configuration();
        public frmLocation()
        {
            InitializeComponent();
        }
        public frmLocation(SignDigitalInfo signInfo)
        {
            SignInfo = signInfo;
            Axle = signInfo.Axle;
            InitializeComponent();
            configuration = configuration.ReadConfiguration();
            SetColorButtonSelected();

        }

        private void btnTopLeft_Click(object sender, EventArgs e)
        {
            CallButton(sender);
        }

        private void btnTopCenter_Click(object sender, EventArgs e)
        {
            CallButton(sender);
        }

        private void btnTopRight_Click(object sender, EventArgs e)
        {
            CallButton(sender);
        }

        private void btnBottomLeft_Click(object sender, EventArgs e)
        {
            CallButton(sender);
        }

        private void btnBottomCenter_Click(object sender, EventArgs e)
        {
            CallButton(sender);
        }

        private void btnBottomRight_Click(object sender, EventArgs e)
        {
            CallButton(sender);
        }

        public void CallButton(object sender)
        {
            ClearAll();
            var btn = (Button)sender;
            btn.BackColor = Color.LightGreen;
            SaveAxle(btn.Text);
        }
        public void ClearAll()
        {
            btnTopLeft.BackColor = Color.Transparent;
            btnTopLeft.ForeColor = Color.Transparent;

            btnTopCenter.BackColor = Color.Transparent;
            btnTopCenter.ForeColor = Color.Transparent;

            btnTopRight.BackColor = Color.Transparent;
            btnTopRight.ForeColor = Color.Transparent;

            btnBottomLeft.BackColor = Color.Transparent;
            btnBottomLeft.ForeColor = Color.Transparent;

            btnBottomCenter.BackColor = Color.Transparent;
            btnBottomCenter.ForeColor = Color.Transparent;

            btnBottomRight.BackColor = Color.Transparent;
            btnBottomRight.ForeColor = Color.Transparent;

            btnHalfRight.BackColor = Color.Transparent;
            btnHalfRight.ForeColor = Color.Transparent;

            btnHalfLeft.BackColor = Color.Transparent;
            btnHalfLeft.ForeColor = Color.Transparent;
        }

        public void SaveAxle(string axle)
        {
            if (configuration != null)
            {
                SignDigitalInfo sign = new SignDigitalInfo();
                sign.Id = this.SignInfo.Id;
                sign.Axle = axle;

                superConn.Connect(@configuration.connectionString);
                signService.UpdateAxle(superConn.conn, sign);
            }
        }

        public Button VerifyButtonIsClicked()
        {
            foreach (var control in gbxAllButtons.Controls)
            {
                if (control is Button)
                {
                    Button button = (Button)control;
                    if ( button.BackColor == Color.LightGreen)
                    {
                        return button;
                    }
                }
            }

            return null;
        }

        public void SetColorButtonSelected()
        {
            if (SignInfo != null)
            {
                foreach (var control in gbxAllButtons.Controls)
                {
                    if (control is Button)
                    {
                        Button button = (Button)control;
                        if (button.Text.Equals(SignInfo.Axle))
                        {
                            button.BackColor = Color.LightGreen;
                            break;
                        }
                    }
                }
            }
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            var btn = VerifyButtonIsClicked();
            if (btn != null)
            {
                this.Axle = btn.Text;
            }
            else
            {
                MessageBox.Show("Selecione a posição da Assinatura!", "Atenção",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            Close();
        }

        private void cbxShowLocation_CheckedChanged(object sender, EventArgs e)
        {
            SignDigitalInfo s = new SignDigitalInfo();
            superConn.Connect(@configuration.connectionString);
            s.Id = this.SignInfo.Id;
            if (cbxShowLocation.Checked)
            {
                s.ShowSignatureLocation = 1;
                signService.UpdateShowSignatureLocation(superConn.conn, s);
                configuration.showLocalization = 1;
            }
            else
            {
                s.ShowSignatureLocation = 0;
                signService.UpdateShowSignatureLocation(superConn.conn, s);
                configuration.showLocalization = 0;
            }

            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter(@"SignBirdID.json"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, configuration);
            }
        }

        private void btnHalfLeft_Click(object sender, EventArgs e)
        {
            CallButton(sender);
        }

        private void btnHalfRight_Click(object sender, EventArgs e)
        {
            CallButton(sender);
        }
    }
}
