using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HackathonApi.Models.Dto
{
    public class Feeling
    {
        [Key]
        public Mood FeelingId { get; set; }
        public string FeelingText { get; set; }
    }
}
