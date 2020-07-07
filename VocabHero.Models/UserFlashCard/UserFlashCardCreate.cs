using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VocabHero.Data.Tables;

namespace VocabHero.Models.UserFlashCard
{
    public class UserFlashCardCreate
    {
        public int UserCardId { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public int FlashCardId { get; set; }
    }
}
