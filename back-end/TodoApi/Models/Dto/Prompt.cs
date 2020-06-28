using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HackathonApi.Models.Dto
{
    public class Prompt
    {
        [Key]
        public int PromptId { get; set; }
        public string PromptText { get; set; }
        public MentalHealth Feeling { get; set; }
        public Mood Mood { get; set; }
        public int Intensity { get; set; }
    }
}
