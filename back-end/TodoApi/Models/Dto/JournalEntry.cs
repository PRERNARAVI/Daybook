using Microsoft.AspNetCore.Hosting.Server.Features;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HackathonApi.Models.Dto
{
    public class JournalEntry
    {
        [Key]
        public int JournalKey { get; set; }
        public string Prompt { get; set; }
        public string Header { get; set; }
        public string Contents { get; set; }
        public DateTime TimeStamped { get; set; }
        public Mood Feeling { get; set; }

    }

    public enum Mood
    {
        Happy,
        Sad,
        Anxious,
        Nervous,
        Stressed,
        Angry
    };

    

}
