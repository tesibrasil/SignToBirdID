using SignBirdID.Controllers;
using SignBirdID.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SignBirdID.Views
{
    public partial class frmLocation : Form
    {
        SignService signService = new SignService();
        public int SignId { get; set; }
       
        Connection superConn = new Connection();

        Configuration configuration = new Configuration();

        public frmLocation()
        {
            InitializeComponent();
            configuration = configuration.ReadConfiguration();
            superConn.Connect(@configuration.connectionString);
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
        }

        public void SaveAxle(string axle)
        {
            //if (configuration != null)
            //{
            //    SignDigitalInfo sign = new SignDigitalInfo();
            //    sign.Id = this.SignId;
            //    sign.Axle = axle;

            //    signService.UpdateAxle(superConn.conn, sign);
            //}
        }


    }
}
