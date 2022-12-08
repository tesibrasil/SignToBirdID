using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Dapper;
using SignBirdID.Models;

namespace SignBirdID.Controllers
{
    public class SignService
    {
        public static SqlTransaction CurrentTransaction { get; set; }
        public SignService() 
        {
            //
        }    

        public SignDigitalInfo GetSignDigitalInfoByDocument(SqlConnection conn, string document)
        {
            using (conn)
            {
                var signDigitalInfo = conn.Query<SignDigitalInfo>("SignBirdID_GetSignDigitalInfoByDocument",
                param: new
                {
                    Documento = document,
                },
                transaction: CurrentTransaction,
                commandType: CommandType.StoredProcedure).FirstOrDefault();

                return signDigitalInfo;
            }
        }


    }
}
