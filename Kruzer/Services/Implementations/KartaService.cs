using Kruzer.Repository.DBOperations;
using Kruzer.Repository.Models.DB;
using Kruzer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Kruzer.Services.Implementations
{
    public class KartaService : IKartaService
    {
        public List<KartaModel> GetKarta()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KruzerDB"].ConnectionString;
            return KartaOperations.GetKarta(connectionString);

        }

        public List<KartaModel> GetFullKartaDetails()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KruzerDB"].ConnectionString;
            return KartaOperations.GetFullKartaDetails(connectionString);

        }

        public KartaModel GetKartaByID(int kartaID)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KruzerDB"].ConnectionString;
            return KartaOperations.GetKartaByID(kartaID, connectionString);
        }

        public bool DeleteKarta(int kartaID)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KruzerDB"].ConnectionString;
            return KartaOperations.DeleteKarta(kartaID, connectionString);
        }
    
        public bool InsertKarta(KartaModel karta)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KruzerDB"].ConnectionString;
            return KartaOperations.InsertKarta(karta, connectionString);

        }

        public bool UpdateKarta(KartaModel karta)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KruzerDB"].ConnectionString;
            return KartaOperations.UpdateKarta(karta, connectionString);

        }
    }
}