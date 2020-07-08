using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VocabHero.Data.Tables
{
    public class FlashCardUserAttempt
    {
        [Key]
        public int UserAttemptId { get; set; }

        public bool IsSuccessful { get; set; }

        //UserFlashCard FK --> FCUA has a many(attempts) to one(flashcard) relationship with UserFlashCard
        [ForeignKey("UserFlashCard")]
        public int UserCardId { get; set; }
        public virtual UserFlashCard UserFlashCard { get; set; }

        //STRETCH GOAL: Add logic in service layer to calculate RankAdd instead of initializing a static value
        public int RankAdd { get; set; } = 10;


    }
}
