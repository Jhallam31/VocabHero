using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VocabHero.Data;
using VocabHero.Data.Tables;
using VocabHero.Models.FlashCard;
using VocabHero.Models.UserFlashCard;
using static VocabHero.Data.ApplicationUser;

namespace VocabHero.Services
{
    public class UserFlashCardService
    {
        private readonly string _userId;       
        public UserFlashCardService(string userId)
        {
            _userId = userId;
        }
        public UserFlashCardService()
        {

        }        
        public bool CreateUserFlashCard(UserFlashCardCreate model)
        {
            
            var entity=
                new UserFlashCard()
                
                {
                    
                    FlashCardId = model.FlashCardId,
                    UserId = model.UserId
                };
            using (var db = new ApplicationDbContext())
            {
                db.UserFlashCards.Add(entity);
                return db.SaveChanges() == 1;
            }
        }
        public IEnumerable<UserFlashCardListItem> GetUserFlashCards()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .UserFlashCards
                        .Where(e => e.UserCardId == e.UserCardId && e.ApplicationUser.Id == _userId)
                        .Select(
                            e =>
                                new UserFlashCardListItem
                                {
                                    UserCardId = e.UserCardId,
                                    Definition = e.FlashCard.Definition
                                }
                        );

                return query.ToArray();
            }
        }
        public bool UpdateUserFlashCard(UserFlashCardEdit model, int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .UserFlashCards
                        .Single(e => e.UserCardId == id && e.ApplicationUser.Id == _userId);
                entity.FlashCard.FlashCardId = model.FlashCardId;
                

                return ctx.SaveChanges() == 1;
            }
        }
        public UserFlashCardDetail GetUserFlashCardById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .UserFlashCards
                        .Single(e => e.UserCardId == id);
                return
                    new UserFlashCardDetail
                    {
                        Word = entity.FlashCard.Word,
                        Definition = entity.FlashCard.Definition,
                        PartOfSpeech = entity.FlashCard.PartOfSpeech

                    };
            }
        }
        public bool DeleteUserFlashCard(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .UserFlashCards
                        .Single(e => e.UserCardId == id && e.ApplicationUser.Id == _userId);

                ctx.UserFlashCards.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

