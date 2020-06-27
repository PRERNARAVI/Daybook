using HackathonApi.Models.Dto;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackathonApi.Models.Service
{
    public class JournalEntryService
    {
        private readonly KeyVaultClient _keyVaultClient;
        public JournalEntryService()
        {
            
        }
        public async Task<JournalEntry> GetTextAnalytics()
        {
            
            return new JournalEntry();
        }
    }
}
