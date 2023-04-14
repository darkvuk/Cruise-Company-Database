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
    public class LukaService : ILukaService
    {
        public List<LukaModel> GetLuka()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KruzerDB"].ConnectionString;
            return LukaOperations.GetLuka(connectionString);
        }

        public LukaModel GetLukaByID(String lukaID)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KruzerDB"].ConnectionString;
            return LukaOperations.GetLukaByID(lukaID, connectionString);
        }

        public bool DeleteLuka(string lukaID)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KruzerDB"].ConnectionString;
            return LukaOperations.DeleteLuka(lukaID, connectionString);
        }

        public bool InsertLuka(LukaModel luka)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KruzerDB"].ConnectionString;
            return LukaOperations.InsertLuka(luka, connectionString);

        }

        public bool UpdateLuka(LukaModel luka)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KruzerDB"].ConnectionString;
            return LukaOperations.UpdateLuka(luka, connectionString);

        }
    }
}