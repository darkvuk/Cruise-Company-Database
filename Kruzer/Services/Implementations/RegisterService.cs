using Kruzer.Repository.DBOperations;
using Kruzer.Repository.Models.DB;
using Kruzer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kruzer.Services.Implementations
{
    public class RegisterService : IRegisterService
    {
        public bool InsertKorisnik(KorisnikModel korisnik)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KruzerDB"].ConnectionString;
            return RegisterOperations.InsertKorisnik(korisnik, connectionString);

        }

        public List<KorisnikModel> GetKorisnik()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KruzerDB"].ConnectionString;
            return RegisterOperations.GetKorisnik(connectionString);
        }
    }
}