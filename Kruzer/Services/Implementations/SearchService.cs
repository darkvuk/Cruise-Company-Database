using Kruzer.Repository.DBOperations;
using Kruzer.Repository.Models.DB;
using Kruzer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kruzer.Services.Implementations
{
    public class SearchService : ISearchService
    {

        public List<LukaModel> GetLukaByCountry(LukaModel luka)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KruzerDB"].ConnectionString;
            return SearchOperations.GetLukaByCountry(luka, connectionString);
        }

        public List<PutnikModel> GetPutnikByCountry(PutnikModel putnik)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KruzerDB"].ConnectionString;
            return SearchOperations.GetPutnikByCountry(putnik, connectionString);
        }

    }
}