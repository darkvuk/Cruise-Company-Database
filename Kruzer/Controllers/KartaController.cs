using Kruzer.Repository.Models.DB;
using Kruzer.Services.Implementations;
using Kruzer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kruzer.Controllers
{
    public class KartaController : Controller
    {

        private IKartaService _kartaService;
        private IKruzerService _kruzerService;
        private IPutnikService _putnikService;

        public KartaController(IKartaService kartaService, IKruzerService kruzerService, IPutnikService putnikService)
        {
            this._kartaService = kartaService;
            this._kruzerService = kruzerService;
            this._putnikService = putnikService;
        }

        // GET: Karta
        public ActionResult Index()
        {
     
            List<KartaModel> karte = this._kartaService.GetFullKartaDetails();
            ViewBag.Karta = karte;
            
            return View();
        }

        public ActionResult ViewKartaDetails(int id)
        {
            KartaModel result = this._kartaService.GetKartaByID(id);
            return View(result);
        }


        public ActionResult DeleteKarta(int id)
        {
            bool result = this._kartaService.DeleteKarta(id);

            if(result == true)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }

        }

        public ActionResult Create()
        {
            
            List<KruzerModel> kruzeri = this._kruzerService.GetKruzer();
            ViewBag.Kruzer = kruzeri;
            List<PutnikModel> putnici = this._putnikService.GetPutnik();
            ViewBag.Putnik = putnici;

            return View("Karta");
        }

        public ActionResult Store(KartaModel karta)
        {
            bool result = false;

            if(karta.Broj == 0)
            {
                result = this._kartaService.InsertKarta(karta);
            }
            else
            {
                result = this._kartaService.UpdateKarta(karta);
            }

            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Karta", karta);
            }
        }

        public ActionResult Edit(int kartaID)
        {

            List<KruzerModel> kruzeri = this._kruzerService.GetKruzer();
            ViewBag.Kruzer = kruzeri;
            List<PutnikModel> putnici = this._putnikService.GetPutnik();
            ViewBag.Putnik = putnici;

            KartaModel karta = this._kartaService.GetKartaByID(kartaID);
            return View("Karta", karta);
        }

    }
}