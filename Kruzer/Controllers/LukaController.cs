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
    public class LukaController : Controller
    {
        private ILukaService _lukaService;
        private IDrzavaService _drzavaService;

        public LukaController(ILukaService lukaService, IDrzavaService drzavaService)
        {
            this._lukaService = lukaService;
            this._drzavaService = drzavaService;
        }

        // GET: Luka
        public ActionResult Index()
        {
            
            List<LukaModel> luke = this._lukaService.GetLuka();
            ViewBag.Luka = luke;

            return View();
        }

        public ActionResult ViewLukaDetails(String id)
        {

            LukaModel result = this._lukaService.GetLukaByID(id);
            return View(result);

        }

        public ActionResult DeleteLuka(String id)
        {
            bool result = this._lukaService.DeleteLuka(id);

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

            List<LukaModel> luke = this._lukaService.GetLuka();
            ViewBag.Luka = luke;
            List<DrzavaModel> drzave = this._drzavaService.GetDrzava();
            ViewBag.Drzava = drzave;

            return View("Luka");
        }
        
        public ActionResult Store(LukaModel luka)
        {

            bool result = false;

            if (luka.KOD != "")
            {
                result = this._lukaService.InsertLuka(luka);
            }
            else
            {
                result = this._lukaService.UpdateLuka(luka);
            }

            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Luka", luka);
            }
        }

        public ActionResult Edit(String lukaID)
        {

            List<DrzavaModel> drzave = this._drzavaService.GetDrzava();
            ViewBag.Drzava = drzave;

            LukaModel luka = this._lukaService.GetLukaByID(lukaID);
            return View("Luka", luka);
        }
    }
}