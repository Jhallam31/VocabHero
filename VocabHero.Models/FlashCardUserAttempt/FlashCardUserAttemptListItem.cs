using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VocabHero.Models.FlashCardUserAttempt
{
    public class FlashCardUserAttemptListItem
    {
        public string Word { get; set; }

        [Display(Name = "Passed?")]
        public bool IsSuccessful { get; set; }

        [Display(Name ="Rank gained")]
        public int XPGained { get; set; }

    }
}
