using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VocabHero.Data.Tables;

namespace VocabHero.Models.FlashCard
{
    public class FlashCardCreate
    {   
        public int FlashCardId { get; set; }
        [Required]
        public string Word { get; set; }
        [Required]
        public string Definition { get; set; }

        [Display(Name = "Part of Speech")]
        public PartOfSpeech PartOfSpeech { get; set; }
    }
}
