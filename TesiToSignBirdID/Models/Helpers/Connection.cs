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


        public string ReadConfiguration() 
        {
            string r = String.Empty;
            string path = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "SignBirdID.json";

            if (!File.Exists(@path))
            {
                MessageBox.Show("O arquivo de configuração não existe!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return "erro";
            }

            string json = File.ReadAllText(@path);

            Configuration conf = JsonConvert.DeserializeObject<Configuration>(json);

            if (string.IsNullOrEmpty(conf.conection))
            {
                MessageBox.Show("Não foi informado o caminho para o banco de dados!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return "erro";
            }

            if(conf.conection.Substring(0,5) == "!enc!")
            {
                r = Crypto.Decrypt(conf.conection.Substring(5));
            }
            else
            {
                r = conf.conection;

                conf.conection = "!enc!" + Crypto.Encrypt(conf.conection);
                
                JsonSerializer serializer = new JsonSerializer();
                using (StreamWriter sw = new StreamWriter(@"SignBirdID.json"))
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, conf);
                }
            }
            
            return r;
        }   

        public SqlConnection PrepareConection()
        {

            return conn;
        }
    }
}
