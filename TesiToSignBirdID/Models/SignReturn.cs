using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignBirdID.Models
{
    public class SignReturn
    {
        public bool HasError { get; set; }
        public string Message { get; set; }

        public SignReturn()
        {
            HasError = false;
            Message = "";
        }
    }
}
