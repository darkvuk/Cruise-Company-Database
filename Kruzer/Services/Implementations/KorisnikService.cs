using Kruzer.Repository.DBOperations;
using Kruzer.Repository.Models.DB;
using Kruzer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kruzer.Services.Implementations
{
    public class KorisnikService : IKorisnikService
    {
        public KorisnikModel Login(KorisnikModel korisnik)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KruzerDB"].ConnectionString;
            return KorisnikOperations.Login(korisnik, connectionString);
        }
        
        public bool Register(KorisnikModel korisnik)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KruzerDB"].ConnectionString;
            return KorisnikOperations.Register(korisnik, connectionString);

        }
    }
}