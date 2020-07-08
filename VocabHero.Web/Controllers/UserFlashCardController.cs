using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VocabHero.Data;
using VocabHero.Models.UserFlashCard;
using VocabHero.Services;

namespace VocabHero.Web.Controllers
{
    public class UserFlashCardController : Controller
    {
 //This probably needs to be changed
        private UserFlashCardService CreateUserFlashCardServiceWithUserAccountID(string id)
        {

            ApplicationUser user = new ApplicationUser();
            user.GetUserID();
            var userFlashCardService = new UserFlashCardService();

            return userFlashCardService;
        }

        // GET: UserFlashCards
        public ActionResult Index()
        {

            var service = CreateUserFlashCardService();
            var model = service.GetUserFlashCards();

            return View(model);
        }

        //GET: Create
        //UserFlashCard/Create
        public ActionResult Create()
        {
            return View();
        }

        //Post: Create
        //UserFlashCard/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserFlashCardCreate model, string id)
        {
            if (ModelState.IsValid)
            {
                return View(model);
            }


            var service = CreateUserFlashCardServiceWithUserAccountID(id);
            service.CreateUserFlashCard(model);

            return RedirectToAction("Index");
        }

        //Get: Details
        //UserFlashCard/Details/{id}
        public ActionResult Details(int id)
        {
            var svc = CreateUserFlashCardService();
            var model = svc.GetUserFlashCardById(id);

            return View(model);
        }

        //Get: Edit
        //UserFlashCard/Edit
        public ActionResult Edit(UserFlashCardEdit model, int id)
        {
            var service = CreateUserFlashCardService();
            service.UpdateUserFlashCard(model, id);
            
            return View(model);
        }

        //POST: Edit
        //UserFlashCard/Edit/{id}
        [HttpPost]
       
        public ActionResult Edit(int id, UserFlashCardEdit model)
        {


            var service = CreateUserFlashCardService();

            
            if (service.UpdateUserFlashCard(model, id))
            {
                TempData["SaveResult"] = "Your flash card was updated.";
                return RedirectToAction("Index");
            }
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Your card could not be updated.");
            }
                return View(model);
           
        }

        //Get: Delete
        //UserFlashCard/Delete/{id}
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateUserFlashCardService();
            var model = svc.GetUserFlashCardById(id);

            return View(model);
        }

        //Post:Delete
        //FlashCard/Delete/{id}
        [HttpPost]
        [ActionName("Delete")]
        
        public ActionResult DeletePost(int id)
        {
            var service = CreateUserFlashCardService();

            service.DeleteUserFlashCard(id);

            TempData["SaveResult"] = "Flash card successfully deleted";

            return RedirectToAction("Index");
        }

        private UserFlashCardService CreateUserFlashCardService()
        {

            var service = new UserFlashCardService();
            return service;
        }
    }
}