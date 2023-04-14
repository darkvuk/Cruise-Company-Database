using Kruzer.Repository.Models.DB;
using Kruzer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kruzer.Controllers
{
    public class KorisnikManagementController : Controller
    {
        
        private IKorisnikService _korisnikService;

        public KorisnikManagementController(IKorisnikService korisnikService)
        {
            this._korisnikService = korisnikService;
        }

        // GET: KorisnikManagement
        public ActionResult Login()
        {
            return View();
        }
        /*
        public ActionResult Register(KorisnikModel korisnik)
        {
            bool result = this._korisnikService.Register(korisnik);
            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("KorisnikManagement", korisnik);
            }
        }*/
        
        public ActionResult Register()
        {
            return View();
        }

    }
}