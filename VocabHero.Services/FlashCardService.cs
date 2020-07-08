using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VocabHero.Data.Tables;
using VocabHero.Models.FlashCard;
using VocabHero.Models.UserFlashCard;
using static VocabHero.Data.ApplicationUser;

namespace VocabHero.Services
{
    public class FlashCardService
    {
       
        public bool CreateFlashCard(FlashCardCreate model)
        {
            var entity =
                new FlashCard()
                
                {

                    Word = model.Word,
                    Definition = model.Definition,
                    PartOfSpeech = model.PartOfSpeech
                };
            
            using (var ctx = new ApplicationDbContext())
            {
                ctx.FlashCards.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<FlashCardListItem> GetFlashCards()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .FlashCards
                        .Where(e => e.FlashCardId == e.FlashCardId)
                        .Select(
                            e =>
                                new FlashCardListItem
                                {
                                    FlashCardId= e.FlashCardId,
                                    Word = e.Word,
                                    Definition = e.Definition,
                                    PartOfSpeech = e.PartOfSpeech,
                                }
                        );

                return query.ToArray();
            }
        }

        public bool UpdateFlashCard(FlashCardEdit model, int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .FlashCards
                        .Single(e => id == e.FlashCardId);
                entity.Word = model.Word;
                entity.Definition = model.Definition;
                entity.PartOfSpeech = model.PartOfSpeech;

                return ctx.SaveChanges() == 1;
            }
        }




        public FlashCardDetail GetFlashCardById(int id)
        { // we need to transform our collection of data objects into a collection data object models ie. UserFlashCardListItems
            //instantiate an empty list of our models
            List<UserFlashCardListItem> userFlashCardListItems = new List<UserFlashCardListItem>();

            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.FlashCards
                        .Single(e => id == e.FlashCardId);
                // iterate through the list, transform each data object into a data object model
                // add each model to our list above
                foreach(var item in entity.UserFlashCards)
                {
                    
                    var model = new UserFlashCardListItem()
                    {
                        UserCardId = item.UserCardId,
                        Word = item.FlashCard.Word,
                       // SuccessfulAttempts = // calculate the successful attempts for the word
                    };

                    userFlashCardListItems.Add(model);
                }

                return
                    new FlashCardDetail
                    {
                        FlashCardId = entity.FlashCardId,
                        Word = entity.Word,
                        Definition = entity.Definition,
                        PartOfSpeech = entity.PartOfSpeech,
                        UserFlashCards = userFlashCardListItems // assign to the property of our new data object model the value of the list we created above
                        
                    };
            }
        }

        public bool DeleteFlashCard(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .FlashCards
                        .Single(e => e.FlashCardId == id);

                ctx.FlashCards.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

