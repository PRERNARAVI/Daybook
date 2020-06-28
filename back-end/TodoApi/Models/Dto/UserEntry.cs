using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackathonApi.Models.Dto
{
    public class UserEntry
    {
        public string Prompt { get; set; }
        public string Contents { get; set; }
        public Mood Feeling { get; set; }
    }
}
