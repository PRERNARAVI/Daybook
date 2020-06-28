using HackathonApi.Models.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackathonApi.Models.Context
{
    public class ProblemContext : DbContext
    {
        public ProblemContext(DbContextOptions<ProblemContext> options) : base(options)
        {

        }

        public DbSet<Problem> Problem { get; set; }
    }
}
