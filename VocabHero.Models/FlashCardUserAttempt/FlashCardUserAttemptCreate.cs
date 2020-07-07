using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VocabHero.Models.FlashCardUserAttempt
{
    public class FlashCardUserAttemptCreate
    {
        public int UserAttemptId { get; set; }
        public bool IsSuccessful { get; set; }
        //public int RankAdd { get; set; } = 10;
        public int UserCardId { get; set; }

    }
}
