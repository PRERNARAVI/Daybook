using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HackathonApi.Models.Dto
{
    public class UserData
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public MentalHealth MentalHealth { get; set; }
    }

    public enum MentalHealth
    {
        Anxiety,
        Depression,
        PTSD,
        EatingDisorder,
        PersonalityDisorder,
        COVID19

    }


}
