using Kruzer.Repository.DBOperations;
using Kruzer.Repository.Models.DB;
using Kruzer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kruzer.Services.Implementations
{
    public class PolService : IPolService
    {
        public List<PolModel> GetPol()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KruzerDB"].ConnectionString;
            return PolOperations.GetPol(connectionString);
        }
    }
}