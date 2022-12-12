using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SignBirdID.Models.Helpers;

namespace SignBirdID.Models
{
    public class Connection
    {
        public SqlConnection conn = new SqlConnection();
        public Connection()
        {
           //
        }


        public SqlConnection Connect(string connectionString)
        {
            conn.ConnectionString = connectionString;

            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
            
            return conn;
        }



        public SqlConnection PrepareConection()
        {

            return conn;
        }
    }
}
