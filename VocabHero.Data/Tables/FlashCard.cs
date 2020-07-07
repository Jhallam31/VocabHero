using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VocabHero.Data.Tables
{

    public enum PartOfSpeech { Verb = 1, adverb, adjective, noun, pronoun, preposition, conjunction, interjection }
    public class FlashCard
    {
        [Key]
        public int FlashCardId { get; set; }

        [Required]
        public string Word { get; set; }

        [Required]

        public string Definition { get; set; }

        [Display(Name = "Part of Speech")]
        public PartOfSpeech PartOfSpeech { get; set; }
        public ICollection<UserFlashCard> UserFlashCards { get; set; }
    }
}



