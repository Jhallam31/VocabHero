using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VocabHero.Data.Tables;
using VocabHero.Models.FlashCardUserAttempt;
using VocabHero.Services;

namespace VocabHero.Web.Controllers
{
    public class FlashCardUserAttemptController : Controller
    {
        // GET: FlashCardUserAttempt
        public ActionResult Index()
        {
            
            var service = CreateFlashCardUserAttemptService();
            var model = service.GetFlashCardUserAttempts();
            
            return View(model);
        }

        //GET: Create
        //FlashCardUserAttempt/Create

        public ActionResult Create()
        {
            return View();
        }

        //Post:Create
        //FlashCardUserAttempt/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FlashCardUserAttemptCreate model)
        {

            if (ModelState.IsValid)
            {
                return View(model);
            }


            var service = CreateFlashCardUserAttemptService();
            service.CreateFlashCardUserAttempt(model);

            return RedirectToAction("Index");
        }

        //GET: Details
        //FlashCardUserAttempt/Detail/{id}
        public ActionResult Details(int id)
        {
            var svc = CreateFlashCardUserAttemptService();
            var model = svc.GetFlashCardUserAttemptById(id);

            return View(model);
        }

        

        private FlashCardUserAttemptService CreateFlashCardUserAttemptService()
        {

            var service = new FlashCardUserAttemptService();
            return service;
        }
    }
}