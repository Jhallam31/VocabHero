using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VocabHero.Data.Tables;
using VocabHero.Models.FlashCard;
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
                        .Single(e => e.FlashCardId == id);
                entity.Word = model.Word;
                entity.Definition = model.Definition;
                entity.PartOfSpeech = model.PartOfSpeech;

                return ctx.SaveChanges() == 1;
            }
        }




        public FlashCardDetail GetFlashCardById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .FlashCards
                        .Single(e => e.FlashCardId == id);
                return
                    new FlashCardDetail
                    {
                        FlashCardId = entity.FlashCardId,
                        Word = entity.Word,
                        Definition = entity.Definition,
                        PartOfSpeech = entity.PartOfSpeech

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

