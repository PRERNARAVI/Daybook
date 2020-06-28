using HackathonApi.Models.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackathonApi.Models.Context
{
    public class PromptContext : DbContext
    {
        public PromptContext(DbContextOptions<PromptContext> options) : base(options)
        {

        }

        public DbSet<Prompt> Prompt { get; set; }
    }
}
