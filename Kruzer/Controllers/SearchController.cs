using Kruzer.Repository.Models.DB;
using Kruzer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kruzer.Controllers
{
    public class SearchController : Controller
    {

        private ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            this._searchService = searchService;
        }


        // GET: Search
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Search(LukaModel luka)
        {
            
            List<LukaModel> luke = this._searchService.GetLukaByCountry(luka);
            ViewBag.Luka = luke;
            return View();
            
        }
    }
}