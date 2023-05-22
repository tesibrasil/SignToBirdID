using Newtonsoft.Json;
using SignBirdID.Models.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SignBirdID.Models
{
    public class Configuration
    {
        public string connectionString { get; set; }
        public string endpoint { get; set; }
        public string clientid { get; set; }
        public string clientsecret { get; set; }
        public int showLocalization { get; set; }

        public Configuration ReadConfiguration()
        {
            Configuration configuration = new Configuration();

            string path = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "SignBirdID.json";

            if (!File.Exists(@path))
            {
                string j = "{\"connectionString\":\"\",\"endpoint\":\"\",\"clientid\":\"\",\"clientsecret\":\"\", \"showLocalization\":1}";
                File.WriteAllText(@path, j);
            }

            string json = File.ReadAllText(@path);

            configuration = JsonConvert.DeserializeObject<Configuration>(json);

            if (string.IsNullOrEmpty(configuration.connectionString))
            {
                MessageBox.Show("Não foi informado o caminho para o banco de dados!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            if (configuration.connectionString.Substring(0, 5) == "!enc!")
            {
                configuration.connectionString = Crypto.Decrypt(configuration.connectionString.Substring(5));
            }
            else
            {
                var temp = configuration.connectionString;
                configuration.connectionString = "!enc!" + Crypto.Encrypt(configuration.connectionString);

                JsonSerializer serializer = new JsonSerializer();
                using (StreamWriter sw = new StreamWriter(@"SignBirdID.json"))
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, configuration);
                }

                configuration.connectionString = temp;
            }



            return configuration;
        }
    }
}
