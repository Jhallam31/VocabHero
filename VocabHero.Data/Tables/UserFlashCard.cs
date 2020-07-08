using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VocabHero.Data.Tables
{
    public class UserFlashCard
    {
        [Key]
        public int UserCardId { get; set; }
        //FlashCard FK
        [ForeignKey("FlashCard")]
        public int FlashCardId { get; set; }
        public virtual FlashCard FlashCard { get; set; }

        //User FK
        [ForeignKey("ApplicationUser")]

        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        //Attempts collection--> UserFlashCard has a one(card) to many(attempts) relationship with UserCardAttempt.cs
        public ICollection<FlashCardUserAttempt> UserAttempts { get; set; }



    }
}
