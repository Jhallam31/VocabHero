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
        // this method gets called from UserCardIndex when we click our "Attempt" button/link
        public ActionResult Create(int id) // id is userCardId from our view
        {
            //our model needs to be able to hold all the information our User needs to answer the question
            //our model needs to be able to hold all the information our Application needs to evaluate the question and record it to the FlashCardUserAttempt table
            // getUserFlashCardById and pass the pertinent info into our model.


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