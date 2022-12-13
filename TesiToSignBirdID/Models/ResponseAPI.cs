using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignBirdID.Models
{
    public class ResponseAPI
    {
        public class Authorize
        {
            public string access_token { get; set; }
            public int expires_in { get; set; }
            public string token_type { get; set; }
            public string scope { get; set; }
            public string provider { get; set; }
            public string authorization { get; set; }
        }
        
        public class Signature
        {
            public string tcn { get; set; }
            public string certificate_alias { get; set; }
        }


        public class GetDownloadURL
        {
            public Documents[] documents { get; set; }
        }

        public class Documents
        {
            public string id { get; set; }
            public string original_file_name { get; set; }
            public string mediatype { get; set; }
            public string status { get; set; }
            public int lifetime { get; set; }
            public string result { get; set; }
            public string checksum { get; set; }
        }
    }
}
