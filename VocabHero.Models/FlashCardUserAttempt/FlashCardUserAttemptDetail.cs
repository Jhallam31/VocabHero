﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VocabHero.Data.Tables;

namespace VocabHero.Models.FlashCardUserAttempt
{
    public class FlashCardUserAttemptDetail
    {
        public string Word { get; set; }
        public string Definition { get; set; }

        [Display(Name ="Part of Speech")]
        public PartOfSpeech PartOfSpeech { get; set; }
        public bool IsSuccessful { get; set; }

        [Display(Name ="Rank gained")]
        public int RankAdd { get; set; }
    }
}
