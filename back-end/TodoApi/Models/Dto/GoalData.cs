using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HackathonApi.Models.Dto
{
    public class GoalData
    {
        [Key]
        public int GoalId { get; set; }
        public string Goal { get; set; }
        public bool IsComplete { get; set; }
        public DateTime CreationTime { get; set; }

        [ForeignKey("UserData")]
        public int UserRefId { get; set; }
        public UserData UserData { get; set; }
    }
}
