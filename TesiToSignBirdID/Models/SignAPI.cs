using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.IO;
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
            
            SignLog.CreateLog("Montou o header da Autorização");

            string json = "{\"client_id\":\""+ configuration.clientid +"\",\"client_secret\":\""+ configuration.clientsecret +"\",\"username\":\""+ cpf +"\",\"password\":\""+ otp +"\",\"grant_type\":\"password\",\"scope\":\"signature_session\",\"lifetime\":43200}";

            request.AddParameter("application/json", json, ParameterType.RequestBody);
            SignLog.CreateLog("Montou o corpo da autorização");
            try
            {
                var response = client.Execute(request);

                if (response.StatusCode != System.Net.HttpStatusCode.OK && response.StatusCode != System.Net.HttpStatusCode.Created)
                {
                    SignLog.CreateLog("Erro: " + response.ErrorMessage);
                    r = "erro";
                }
                else
                {
                    r = response.Content;
                };

            }
            catch (Exception ex)
            {
                SignLog.CreateLog("Erro: " + ex.Message);
                r = "erro";
            }
           
            return r;
        }



        public static string Signature(Configuration configuration, SignDigitalInfo signInfo, string[] parameters)
        {
            
            var r = "";
            string[] axle = signInfo.Axle.Split(':');

            var client = new RestClient($"http://{configuration.endpoint}/signature-service");
           
            RestRequest request = new RestRequest("", Method.Post);
            
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", signInfo.Authorization);
           
            SignLog.CreateLog("Montou o header da assinatura");

            string base64File = ConvertFileToBase64(parameters[2]);
            SignLog.CreateLog("Montou o base64 do arquivo");

            string json = "{\"certificate_alias\": \"\",\"type\": \"PDFSignature\",\"hash_algorithm\": \"SHA256\",\"auto_fix_document\": true,"+
                "\"signature_settings\": [{\"id\": \"default\",\"contact\": \"123456789\",\"location\": \"SaoPauloSP\",\"reason\": \"Aprovação de documento\","+
                "\"visible_signature\": true,\"visible_sign_x\": "+ axle[0] +",\"visible_sign_y\": "+ axle[1] + ",\"visible_sign_width\": 230,\"visible_sign_height\": 50,"+
                "\"visible_sign_page\": 1,\"extraInfo\":[]}],\"documents_source\": \"DATA_URL\",\"documents\": [{\"id\": \""+ parameters[1] +"\",\"signature_setting\": \"default\","+
                "\"original_file_name\": \"TESTE-ASSINATURA.pdf\",\"data\": \"data:application/pdf;base64,"+ base64File +"\"}]}";

    
            request.AddParameter("application/json", json, ParameterType.RequestBody);


            SignLog.CreateLog("Montou o body da assinatura");
            try
            {
                var response = client.Execute(request);
                SignLog.CreateLog("Efetuou o execute Request");
                if (response.StatusCode != System.Net.HttpStatusCode.OK && response.StatusCode != System.Net.HttpStatusCode.Created)
                {
                    SignLog.CreateLog("Erro: "+ response.Content);
                    MessageBox.Show("Erro: \n" + response.Content,"Erro",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    r = "erro";
                }
                else
                {
                    r = response.Content;
                };

            }
            catch (Exception ex)
            {
                SignLog.CreateLog("Erro: " + ex.Message);
                MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                r = "erro";
            }

            return r;
        }


        private static string ConvertFileToBase64(string FilePath)
        {
            byte[] temp = File.ReadAllBytes(FilePath);

            string temp64 = Convert.ToBase64String(temp);

            return temp64;
        }


        public static string GetDownloadURL(Configuration configuration, string tcn, SignDigitalInfo signInfo)
        {
            var r = "";
            var client = new RestClient($"http://{configuration.endpoint}");
            RestRequest request = new RestRequest($"signature-service/{tcn}", Method.Get);

            var authenticator = new JwtAuthenticator(signInfo.AccessNumber);
            client.Authenticator = authenticator;
            
            try
            {
                var response = client.Execute(request);

                if (response.StatusCode != System.Net.HttpStatusCode.OK && response.StatusCode != System.Net.HttpStatusCode.Created)
                {
                    MessageBox.Show("Erro: \n" + response.ErrorMessage, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    r = "erro";
                }
                else
                {
                    r = response.Content;
                };

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                r = "erro";
            }

            return r;
        }
    }
}
