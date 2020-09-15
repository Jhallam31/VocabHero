using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VocabHero.Models.FlashCardUserAttempt
{
    public class FlashCardUserAttemptListItem
    {
        public string Word { get; set; }

        [Display(Name = "Correct?")]
        public bool AttemptSuccessful { get; set; }

        [Display(Name = "XP gained")]
        public int XPGained { get; set; }

    }
}
