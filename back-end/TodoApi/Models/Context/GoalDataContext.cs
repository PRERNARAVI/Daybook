using HackathonApi.Models.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackathonApi.Models.Context
{
    public class GoalDataContext: DbContext
    {
        public GoalDataContext(DbContextOptions<GoalDataContext> options) : base(options)
        {

        }

        public DbSet<GoalData> GoalData { get; set; }
    }
}
