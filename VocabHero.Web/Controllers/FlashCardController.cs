using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VocabHero.Models.FlashCard;
using VocabHero.Services;

namespace VocabHero.Web.Controllers
{
    
    public class FlashCardController : Controller
    {
        // GET: FlashCards
        public ActionResult Index()
        {

            var service = new FlashCardService();
            var model = service.GetFlashCards();

            return View(model);
        }

        //GET: Create
        //FlashCard/Create
        public ActionResult Create()
        {
            return View();
        }

        //Post: Create
        //FlashCard/Create

        [HttpPost]
        
        public ActionResult Create(FlashCardCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }


            var service = new FlashCardService();

            service.CreateFlashCard(model);

            return RedirectToAction("Index");
        }

        //Get: Details
        //FlashCard/Details/{id}
        public ActionResult Details(int id)
        {
            var svc = CreateFlashCardService();
            var model = svc.GetFlashCardById(id);

            return View(model);
        }

        //Get: Edit
        //FlashCard/Edit
        public ActionResult Edit(int id)
        {
            var service = CreateFlashCardService();
            var detail = service.GetFlashCardById(id);
            var model =
                new FlashCardEdit
                {
                   
                    Word = detail.Word,
                    Definition = detail.Definition,
                    PartOfSpeech = detail.PartOfSpeech
                };
            return View(model);
        }

        //POST: Edit
        //FlashCard/Edit/{id}
        [HttpPost]
        
        public ActionResult Edit(string word, FlashCardEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            //if (model.FlashCardId != id)
            //{
            //    ModelState.AddModelError("", "Flash card not found");
            //    return View(model);
            //}

            var service = CreateFlashCardService();

            if (service.UpdateFlashCard(model,word))
            {
                TempData["SaveResult"] = "Your flash card was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your card could not be updated.");
            return View(model);
        }

        //Get: Delete
        //FlashCard/Delete/{id}
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateFlashCardService();
            var model = svc.GetFlashCardById(id);

            return View(model);
        }

        //Post:Delete
        //FlashCard/Delete/{id}
        [HttpPost]
        [ActionName("Delete")]
        
        public ActionResult DeletePost(string word)
        {
            var service = CreateFlashCardService();

            service.DeleteFlashCard(word);

            TempData["SaveResult"] = "Your card was deleted";

            return RedirectToAction("Index");
        }

        private FlashCardService CreateFlashCardService()
        {
            
            var service = new FlashCardService();
            return service;
        }
    }
}