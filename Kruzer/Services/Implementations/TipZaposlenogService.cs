using Kruzer.Repository.DBOperations;
using Kruzer.Repository.Models.DB;
using Kruzer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kruzer.Services.Implementations
{
    public class TipZaposlenogService : ITipZaposlenogService
    {
        public List<TipZaposlenogModel> GetTipZaposlenog()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KruzerDB"].ConnectionString;
            return TipZaposlenogOperations.GetTipZaposlenog(connectionString);
        }
    }
}