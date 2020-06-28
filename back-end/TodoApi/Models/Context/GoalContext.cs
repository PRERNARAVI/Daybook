using HackathonApi.Models.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackathonApi.Models.Context
{
    public class GoalContext : DbContext
    {
        public GoalContext(DbContextOptions<GoalContext> options) : base(options)
        {

        }

        public DbSet<Goal> Goal { get; set; }
    }
}
