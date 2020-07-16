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
        [Display(Name = "Correct?")]
        public bool IsSuccessful { get; set; }
        public string Guess { get; set; }

        [Display(Name = "XP gained")]
        public int XPGained { get; set; }
        public UserFlashCardDetail UserFlashCard {get; set;}
        
    }
}
