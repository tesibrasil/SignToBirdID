using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Essy.Tools.InputBox;
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

            /* if(args.Length != 3 && args.Length != 0)
             {
                 SignLog.CreateLog("-------------------------------- passo 1 --------------------------------");
                 return 1;
             }
            */
            //frmLocation location = new frmLocation(new SignDigitalInfo());
            //Application.Run(location);
            //return 0;

            frmPrincipal principal = new frmPrincipal(args);
            Application.Run(principal);

            return principal.DiddyReturn;


        }
    }
}
