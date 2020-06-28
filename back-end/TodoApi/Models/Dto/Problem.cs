using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HackathonApi.Models.Dto
{
    public class Problem
    {
        [Key]
        public MentalHealth ProblemId { get; set; }
        public string OptionText { get; set; }
    }
}
