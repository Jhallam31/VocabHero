using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VocabHero.Data.Tables;
using VocabHero.Models.UserFlashCard;

namespace VocabHero.Models.FlashCard
{
    public class FlashCardDetail
    {
        public int FlashCardId { get; set; }
        public string Word { get; set; }
        public string Definition { get; set; }

        [Display(Name = "Part of Speech")]
        public PartOfSpeech PartOfSpeech { get; set; }

        //Using ListItem Model here because we want the ListItem properties, not the generic ones
        public List<UserFlashCardListItem> UserFlashCards { get; set; }
    }
}
