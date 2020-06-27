using HackathonApi.Models.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackathonApi.Models.Context
{
    public class JournalEntryContext: DbContext
    {
        public JournalEntryContext(DbContextOptions<JournalEntryContext> options):base(options)
        {

        }

        public DbSet<JournalEntry> JournalEntry { get; set; }
    }
}
