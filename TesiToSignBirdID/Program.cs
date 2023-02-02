using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SignBirdID.Models;
using SignBirdID.Views;

namespace SignBirdID
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static int Main(string [] args)
        {
            SignLog.CreateLog("-------------------------------- PROCESSO INICIADO --------------------------------");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            frmLocation principal = new frmLocation();
            Application.Run(principal);
            //frmPrincipal principal = new frmPrincipal(args);
            //Application.Run(principal);

            //return principal.DiddyReturn;
            return 0;
        }
    }
}
