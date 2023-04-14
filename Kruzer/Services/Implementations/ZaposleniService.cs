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
    public class ZaposleniService : IZaposleniService 
    {
        public List<ZaposleniModel> GetZaposleni()
        {

            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KruzerDB"].ConnectionString;
            return ZaposleniOperations.GetZaposleni(connectionString);

        }

        public ZaposleniModel GetZaposleniByID(int zaposleniID)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KruzerDB"].ConnectionString;
            return ZaposleniOperations.GetZaposleniByID(zaposleniID, connectionString);
        }

        public bool DeleteZaposleni(int zaposleniID)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KruzerDB"].ConnectionString;
            return ZaposleniOperations.DeleteZaposleni(zaposleniID, connectionString);
        }

        public bool InsertZaposleni(ZaposleniModel zaposleni)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KruzerDB"].ConnectionString;
            return ZaposleniOperations.InsertZaposleni(zaposleni, connectionString);

        }

        public bool UpdateZaposleni(ZaposleniModel zaposleni)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KruzerDB"].ConnectionString;
            return ZaposleniOperations.UpdateZaposleni(zaposleni, connectionString);

        }


    }
}