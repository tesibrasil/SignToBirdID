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
        public frmLocation()
        {
            InitializeComponent();
        }



        public void ClearAll()
        {
            btnTopLeft.BackColor = Color.Transparent;
            btnTopCenter.BackColor = Color.Transparent;
            btnTopRight.BackColor = Color.Transparent;

            btnBottomLeft.BackColor = Color.Transparent;
            btnBottomCenter.BackColor = Color.Transparent;
            btnBottomRight.BackColor = Color.Transparent;
        }

        private void btnTopLeft_Click(object sender, EventArgs e)
        {
            ClearAll();
            btnTopLeft.BackColor = Color.LightGreen;
        }

        private void btnTopCenter_Click(object sender, EventArgs e)
        {
            ClearAll();
            btnTopCenter.BackColor = Color.LightGreen;
        }

        private void btnTopRight_Click(object sender, EventArgs e)
        {
            ClearAll();
            btnTopRight.BackColor = Color.LightGreen;
        }

        private void btnBottomLeft_Click(object sender, EventArgs e)
        {
            ClearAll();
            btnBottomLeft.BackColor = Color.LightGreen;
        }

        private void btnBottomCenter_Click(object sender, EventArgs e)
        {
            ClearAll();
            btnBottomCenter.BackColor = Color.LightGreen;
        }

        private void btnBottomRight_Click(object sender, EventArgs e)
        {
            ClearAll();
            btnBottomRight.BackColor = Color.LightGreen;
        }
    }
}
