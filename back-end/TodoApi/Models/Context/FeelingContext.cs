using HackathonApi.Models.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackathonApi.Models.Context
{
    public class FeelingContext : DbContext
    {
        public FeelingContext(DbContextOptions<FeelingContext> options) : base(options)
        {

        }

        public DbSet<Feeling> Feeling { get; set; }
    }
}
