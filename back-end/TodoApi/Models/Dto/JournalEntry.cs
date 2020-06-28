using Microsoft.AspNetCore.Hosting.Server.Features;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HackathonApi.Models.Dto
{
    public class JournalEntry
    {
        [Key]
        public int JournalKey { get; set; }
        public DateTime TimeStamped { get; set; }
        public string Prompt { get; set; }
        public string Contents { get; set; }
        public Mood Feeling { get; set; }
        public string Keywords { get; set; }
        public double Positive { get; set; }
        public double Negative { get; set; }
        public double Neutral { get; set; }

        [ForeignKey("UserData")]
        public int UserRefId { get; set; }
        public UserData UserData { get; set; }

    }

    public enum Mood
    {
        Happy,
        Sad,
        Angry,
        Afraid,
        Disgusted,
        Surprised
    };
    
}
