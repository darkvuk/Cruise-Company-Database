using Kruzer.Repository.Models.DB;
using Kruzer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kruzer.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View("CustomView");
        }

        
    }
}