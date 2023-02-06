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

        //GET
        public SignDigitalInfo GetSignDigitalInfoByDocument(SqlConnection conn, string document)
        {
            using (conn)
            {
                var signDigitalInfo = conn.Query<SignDigitalInfo>("SP_SignBirdID_GetSignDigitalInfoByDocument",
                param: new
                {
                    Documento = document
                },
                transaction: CurrentTransaction,
                commandType: CommandType.StoredProcedure).FirstOrDefault();

                return signDigitalInfo;
            }
        }

        //CREATE
        public int CreateSignDigitalInfo(SqlConnection conn, SignDigitalInfo signDigitalInfo)
        {
            using (conn)
            {
                var id = conn.ExecuteScalar<int>("SP_SignBirdID_CreateSignDigitalInfo",
                param: new
                {
                    Documento = signDigitalInfo.Document,
                    Cliente_ID = signDigitalInfo.ClientID,
                    Cliente_Segreto = signDigitalInfo.ClientSecret,
                    Numero_Acesso = signDigitalInfo.AccessNumber,
                    Data_Di_Scadenza = signDigitalInfo.ExpirationDate,
                    Autorizzazione = signDigitalInfo.Authorization,
                    Mostra_Posizione_Firma = signDigitalInfo.ShowSignatureLocation,
                    Asse = signDigitalInfo.Axle,
                    Eliminato = signDigitalInfo.Disabled
                },
                transaction: CurrentTransaction,
                commandType: CommandType.StoredProcedure);

                return id;
            }
        }

        //UPDATE
        public int UpdateSignDigitalInfo(SqlConnection conn, SignDigitalInfo signDigitalInfo)
        {
            using (conn)
            {
                var id = conn.ExecuteScalar<int>("SP_SignBirdID_UpdateSignDigitalInfo",
                param: new
                {
                    id = signDigitalInfo.Id,
                    Numero_Acesso = signDigitalInfo.AccessNumber,
                    Data_Di_Scadenza = signDigitalInfo.ExpirationDate,
                    Autorizzazione = signDigitalInfo.Authorization
                },
                transaction: CurrentTransaction,
                commandType: CommandType.StoredProcedure);

                return id;
            }
        }

        public int UpdateShowSignatureLocation(SqlConnection conn, SignDigitalInfo signDigitalInfo)
        {
            using (conn)
            {
                var id = conn.ExecuteScalar<int>("SP_SignBirdID_UpdateShowSignatureLocation",
                param: new
                {
                    id = signDigitalInfo.Id,
                    Mostra_Posizione_Firma = signDigitalInfo.ShowSignatureLocation
                },
                transaction: CurrentTransaction,
                commandType: CommandType.StoredProcedure);

                return id;
            }
        }

        public int UpdateAxle(SqlConnection conn, SignDigitalInfo signDigitalInfo)
        {
            using (conn)
            {
                var id = conn.ExecuteScalar<int>("SP_SignBirdID_UpdateAxle",
                param: new
                {
                    id = signDigitalInfo.Id,
                    Asse = signDigitalInfo.Axle
                },
                transaction: CurrentTransaction,
                commandType: CommandType.StoredProcedure);

                return id;
            }
        }
    }
}
