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
    public class PutnikController : Controller
    {
        private IPutnikService _putnikService;
        private IDrzavaService _drzavaService;
        private IPolService _polService;

        public PutnikController(IPutnikService putnikService, IDrzavaService drzavaService, IPolService polService)
        {
            this._putnikService = putnikService;
            this._drzavaService = drzavaService;
            this._polService = polService;
        }

        // GET: Putnik
        public ActionResult Index()
        {
            
            List<PutnikModel> putnici = this._putnikService.GetPutnik();
            ViewBag.Putnik = putnici;

            return View();
        }

        public ActionResult ViewPutnikDetails(int id)
        {
            PutnikModel result = this._putnikService.GetPutnikByID(id);
            return View(result);
        }

        public ActionResult DeletePutnik(int id)
        {
            bool result = this._putnikService.DeletePutnik(id);

            if (result == true)
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

            List<PolModel> polovi = this._polService.GetPol();
            ViewBag.Pol = polovi;
            List<DrzavaModel> drzave = this._drzavaService.GetDrzava();
            ViewBag.Drzava = drzave;

            return View("Putnik");
        }

        public ActionResult Store(PutnikModel putnik)
        {

            bool result = false;
            if (putnik.ID == 0)
            {
                result = this._putnikService.InsertPutnik(putnik);
            }
            else
            {
                result = this._putnikService.UpdatePutnik(putnik);
            }

            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Putnik", putnik);
            }

        }

        public ActionResult Edit(int putnikID)
        {

            List<PolModel> polovi = this._polService.GetPol();
            ViewBag.Pol = polovi;
            List<DrzavaModel> drzave = this._drzavaService.GetDrzava();
            ViewBag.Drzava = drzave;

            PutnikModel putnik = this._putnikService.GetPutnikByID(putnikID);
            return View("Putnik", putnik);
        }

    }
}