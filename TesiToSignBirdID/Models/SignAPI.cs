using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SignBirdID.Models
{
    public class SignAPI
    {
        public SignAPI()
        {
            //
        }

       public static string Authorize(Configuration configuration, string otp, string cpf)
        {
            var r = "";
            var client = new RestClient($"http://{configuration.endpoint}/oauth");
            RestRequest request = new RestRequest("", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");

            string json = "{\"client_id\":\""+ configuration.clientid +"\",\"client_secret\":\""+ configuration.clientsecret +"\",\"username\":\""+ cpf +"\",\"password\":\""+ otp +"\",\"grant_type\":\"password\",\"scope\":\"signature_session\",\"lifetime\":43200}";

            request.AddParameter("application/json", json, ParameterType.RequestBody);

            try
            {
                var response = client.Execute(request);

                if (response.StatusCode != System.Net.HttpStatusCode.OK && response.StatusCode != System.Net.HttpStatusCode.Created)
                {
                    MessageBox.Show("Erro: \n" + response.ErrorMessage);
                    r = "erro";
                }
                else
                {
                    r = response.Content;
                };

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
                r = "erro";
            }
           
            return r;
        }  

    }
}
