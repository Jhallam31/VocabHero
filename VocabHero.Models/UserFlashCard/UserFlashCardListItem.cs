using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VocabHero.Models.UserFlashCard
{
    public class UserFlashCardListItem
    {
        public int UserCardId { get; set; }
        public string Word { get; set; }
        public int SuccessfulAttempts { get; set; }
    }
}
