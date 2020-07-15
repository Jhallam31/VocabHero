using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VocabHero.Data.Tables;
using VocabHero.Models.FlashCard;
using VocabHero.Models.UserFlashCard;

namespace VocabHero.Models.FlashCardUserAttempt
{
    public class FlashCardUserAttemptCreate
    {
       // public int UserAttemptId { get; set; }
        public bool IsSuccessful { get; set; }
        public string Guess { get; set; }

        // public int XPGained { get; set; } = 10;
        public UserFlashCardDetail UserFlashCard {get; set;}
        //public string Word { get; set; }
        //public string Definition { get; set; }

        //[Display(Name ="Part of Speech")]
        //public PartOfSpeech PartOfSpeech { get; set; }
    }
}
