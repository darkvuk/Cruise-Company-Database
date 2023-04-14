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
    public class PutnikService : IPutnikService
    {
        public List<PutnikModel> GetPutnik()
        {

            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KruzerDB"].ConnectionString;
            return PutnikOperations.GetPutnik(connectionString);

        }

        public PutnikModel GetPutnikByID(int putnikID)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KruzerDB"].ConnectionString;
            return PutnikOperations.GetPutnikByID(putnikID, connectionString);
        }

        public bool DeletePutnik(int putnikID)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KruzerDB"].ConnectionString;
            return PutnikOperations.DeletePutnik(putnikID, connectionString);
        }

        public bool InsertPutnik(PutnikModel putnik)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KruzerDB"].ConnectionString;
            return PutnikOperations.InsertPutnik(putnik, connectionString);

        }

        public bool UpdatePutnik(PutnikModel putnik)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KruzerDB"].ConnectionString;
            return PutnikOperations.UpdatePutnik(putnik, connectionString);

        }

    }
}