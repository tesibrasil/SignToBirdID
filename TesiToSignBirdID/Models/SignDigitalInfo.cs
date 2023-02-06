using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignBirdID.Models
{
    public class SignDigitalInfo
    {
        public int Id { get; set; }
        public string Document { get; set; }
        public string ClientID { get; set; }    
        public string ClientSecret { get; set; }
        public string AccessNumber { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Authorization { get; set; }
        public int ShowSignatureLocation { get; set; }
        public string Axle { get; set; }
        public int Disabled { get; set; }

        public SignDigitalInfo()
        {
            //
        }
    }
}
