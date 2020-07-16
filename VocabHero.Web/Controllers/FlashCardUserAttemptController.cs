using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using VocabHero.Data.Tables;
using VocabHero.Models.FlashCard;
using VocabHero.Models.FlashCardUserAttempt;
using VocabHero.Models.UserFlashCard;
using VocabHero.Services;
using static VocabHero.Data.ApplicationUser;

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
        
        public ActionResult Create(int id) // id is userCardId from our view
        {
            

            UserFlashCardService svc = new UserFlashCardService();
            
                    var model = new FlashCardUserAttemptCreate()
                    {   
                        UserFlashCard = svc.GetUserFlashCardById(id),                       
                    };          
                    return View(model);
        }



        //Post:Create
        //FlashCardUserAttempt/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FlashCardUserAttemptCreate model)
        {
            if (model.IsSuccessful == false)
            {
                TempData["UnsuccessfulAttempt"] = "Incorrect. Try again!";
                return View();
            }
            else
            {
            var service = CreateFlashCardUserAttemptService();
            service.CreateFlashCardUserAttempt(model);

                TempData["SuccessfulAttempt"] = "Correct!";
                return RedirectToAction("Index","UserFlashCard");
            }
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