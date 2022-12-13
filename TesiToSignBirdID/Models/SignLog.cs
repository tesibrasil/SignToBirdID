using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignBirdID.Models
{
    public class SignLog
    {
        public static void CreateLog(string message)
        {
            if (!File.Exists("SignBirdId.log"))
            {
               StreamWriter temp = new StreamWriter("SignBirdId.log", true, Encoding.UTF8);
              temp.Close();
            
            }

            StreamWriter sw = new StreamWriter("SignBirdId.log", true, Encoding.UTF8);

            sw.WriteLine("-" + DateTime.Now.ToString("dd-MM-yyyy:hh:mm:ss") + "- " + message);
            sw.Close();
        }
    }
}
