using HackathonApi.Models.Dto;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics;
using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackathonApi.Models.Service
{
    public class JournalEntryService
    {
        public async Task<JournalEntry> GetTextAnalytics()
        {
            TextAnalyticsClient textClient = default;
            return new JournalEntry();
        }
    }
}
