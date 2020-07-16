using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using VocabHero.Data.Tables;
using VocabHero.Models.FlashCardUserAttempt;
using VocabHero.Models.UserFlashCard;
using static VocabHero.Data.ApplicationUser;

namespace VocabHero.Services
{
    public class FlashCardUserAttemptService
    {
        private readonly string _userId;
        public FlashCardUserAttemptService() { }
        public bool CreateFlashCardUserAttempt(FlashCardUserAttemptCreate model)
        {
            
            if (model.Guess != model.UserFlashCard.Word)
            {
                model.IsSuccessful = false;
                
            }
            else
            {
                model.IsSuccessful = true;
                model.XPGained = 10;
            }

            var entity=

                 new FlashCardUserAttempt()

                 {
                     Guess = model.Guess,
                     IsSuccessful = model.IsSuccessful,
                     UserCardId = model.UserFlashCard.UserCardId,
                     XPGained = model.XPGained,
                     
                 };


            

        

            using (var ctx = new ApplicationDbContext())
            {

                ctx.FlashCardUserAttempts.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }


        public IEnumerable<FlashCardUserAttemptListItem> GetFlashCardUserAttempts()
{
    using (var ctx = new ApplicationDbContext())
    {
        var query =
            ctx
                .FlashCardUserAttempts
                .Where(e => e.UserCardId == e.UserCardId && e.UserFlashCard.ApplicationUser.Id == _userId)
                .Select(
                    e =>
                        new FlashCardUserAttemptListItem
                        {
                            Word = e.UserFlashCard.FlashCard.Word,
                            IsSuccessful = e.IsSuccessful,
                                    //XPGained = e.XPGained,
                                }
                );

        return query.ToArray();
    }
}

//Update not needed. I do not want the ability to update an attempt.

//public bool UpdateFlashCardUserAttempt(FlashCardUserAttemptEdit model, int id)
//{
//    using (var ctx = new ApplicationDbContext())
//    {
//        var entity =
//            ctx
//                .UserFlashCards
//                .Single(e => e.UserCardId == id && e.AppUser.Id == _userId);
//        entity.FlashCard.FlashCardId = model.FlashCardId;


//        return ctx.SaveChanges() == 1;
//    }
//}




public FlashCardUserAttemptDetail GetFlashCardUserAttemptById(int id)
{
    using (var ctx = new ApplicationDbContext())
    {
        var entity =
            ctx
                .FlashCardUserAttempts
                .Single(e => e.UserAttemptId == id);
        return
            new FlashCardUserAttemptDetail
            {
                Word = entity.UserFlashCard.FlashCard.Word,
                Definition = entity.UserFlashCard.FlashCard.Definition,
                PartOfSpeech = entity.UserFlashCard.FlashCard.PartOfSpeech,
                IsSuccessful = entity.IsSuccessful,
                        //XPGained = entity.XPGained

                    };
    }
}
        //Delete not needed. I do not want the ability to delete attempts.


        //public bool DeleteUserFlashCard(int id)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var entity =
        //            ctx
        //                .UserFlashCards
        //                .Single(e => e.UserCardId == id && e.AppUser.Id == _userId);

        //        ctx.UserFlashCards.Remove(entity);

        //        return ctx.SaveChanges() == 1;
        //    }
        //}
        //public string GetUserID()
        //{
        //    ApplicationUser user = new ApplicationUser();
        //    string userId = user.Id;
        //    return userId;

        //}
    }
}



