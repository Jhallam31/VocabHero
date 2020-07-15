using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VocabHero.Data;
using VocabHero.Data.Tables;
using static VocabHero.Data.ApplicationUser;

namespace VocabHero.Web.Controllers
{
    public class HomeController : Controller
    {

        
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Dictionary()
        {
            ViewBag.Message = "Our dictionary of flash cards.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}