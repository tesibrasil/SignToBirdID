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
    public partial class FrmSigningProcess : Form
    {
        public FrmSigningProcess()
        {
            InitializeComponent();
        }

        private void pbxLoad_Click(object sender, EventArgs e)
        {
            
        }

        private void pbxLoad_DoubleClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
