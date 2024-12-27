﻿namespace Tabu.Entities
{
    public class Game
    {
        public Guid Id { get; set; }
        public int BannedWordCount { get; set; }
        public int FailCount { get; set; }
        public int SkipCount { get; set; }
        public int Time { get; set; }
        public int? Score { get; set; }
        public int? SuccessAnswer { get; set; }
        public int? FailureAnswer { get; set; }
        public string LanguageCode { get; set; }
        public Language Language { get; set; }
    }
}
