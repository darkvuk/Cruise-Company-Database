using Kruzer.Repository.Models.DB;
using Kruzer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kruzer.Controllers
{
    public class RegisterController : Controller
    {

        private IRegisterService _registerService;

        public RegisterController(IRegisterService registerService)
        {
            this._registerService = registerService;
        }

        public ActionResult Index()
        {
            return View();
        }
        // GET: Register
        public ActionResult Create()
        {
            List<KorisnikModel> korisnici = this._registerService.GetKorisnik();
            ViewBag.Korisnik = korisnici;
            return View("Register");
        }

        public ActionResult Store(KorisnikModel korisnik)
        {

            bool result = this._registerService.InsertKorisnik(korisnik);
            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Register", korisnik);
            }
        }
    }
}