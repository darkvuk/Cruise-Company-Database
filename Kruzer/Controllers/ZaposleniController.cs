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
    public class ZaposleniController : Controller
    {
        private IZaposleniService _zaposleniService;
        private IKruzerService _kruzerService;
        private IDrzavaService _drzavaService;
        private ITipZaposlenogService _tipZaposlenogService;
        private IPolService _polService;

        public ZaposleniController(IZaposleniService zaposleniService, 
                                   IKruzerService kruzerService,
                                   IDrzavaService drzavaService,
                                   ITipZaposlenogService tipZaposlenogService,
                                   IPolService polService)
        {
            this._zaposleniService = zaposleniService;
            this._kruzerService = kruzerService;
            this._drzavaService = drzavaService;
            this._tipZaposlenogService = tipZaposlenogService;
            this._polService = polService;

        }

        // GET: Zaposleni
        public ActionResult Index()
        {
            
            List<ZaposleniModel> zaposleni = this._zaposleniService.GetZaposleni();
            ViewBag.Zaposleni = zaposleni;

            return View();
        }

        public ActionResult ViewZaposleniDetails(int id)
        {
            ZaposleniModel result = this._zaposleniService.GetZaposleniByID(id);
            return View(result);
        }

        public ActionResult DeleteZaposleni(int id)
        {
            bool result = this._zaposleniService.DeleteZaposleni(id);

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

            List<KruzerModel> kruzeri = this._kruzerService.GetKruzer();
            ViewBag.Kruzer = kruzeri;
            List<DrzavaModel> drzave = this._drzavaService.GetDrzava();
            ViewBag.Drzava = drzave;
            List<TipZaposlenogModel> tipovi = this._tipZaposlenogService.GetTipZaposlenog();
            ViewBag.Tip = tipovi;
            List<PolModel> polovi = this._polService.GetPol();
            ViewBag.Pol = polovi;

            return View("Zaposleni");
        }
        /*
        public ActionResult Store(ZaposleniModel zaposleni)
        {

            bool result = this._zaposleniService.InsertZaposleni(zaposleni);
            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Zaposleni", zaposleni);
            }
        }*/

        public ActionResult Store(ZaposleniModel zaposleni)
        {

            bool result = false;
            if (zaposleni.ID == 0)
            {
                result = this._zaposleniService.InsertZaposleni(zaposleni);
            }
            else
            {
                result = this._zaposleniService.UpdateZaposleni(zaposleni);
            }

            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Zaposleni", zaposleni);
            }

        }

        public ActionResult Edit(int zaposleniID)
        {

            List<KruzerModel> kruzeri = this._kruzerService.GetKruzer();
            ViewBag.Kruzer = kruzeri;
            List<DrzavaModel> drzave = this._drzavaService.GetDrzava();
            ViewBag.Drzava = drzave;
            List<TipZaposlenogModel> tipovi = this._tipZaposlenogService.GetTipZaposlenog();
            ViewBag.Tip = tipovi;
            List<PolModel> polovi = this._polService.GetPol();
            ViewBag.Pol = polovi;

            ZaposleniModel zaposleni = this._zaposleniService.GetZaposleniByID(zaposleniID);
            return View("Zaposleni", zaposleni);
        }

    }
}