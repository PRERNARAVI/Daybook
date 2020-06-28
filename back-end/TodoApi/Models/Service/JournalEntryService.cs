using HackathonApi.Models.Dto;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Azure.AI.TextAnalytics;
using System.Globalization;
using Microsoft.Extensions.Configuration;
using Microsoft.Azure.CognitiveServices.Personalizer;
using Microsoft.Rest;
using Microsoft.Azure.CognitiveServices.Personalizer.Models;
using Microsoft.CodeAnalysis.CodeActions;
using HackathonApi.Models.Context;
using HackathonApi.Controllers;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace HackathonApi.Models.Service
{
    public class JournalEntryService
    {
        private readonly TextAnalyticsClient _textAnalyticsClient;
        private readonly PersonalizerClient _personalizerClient;
        private readonly KeyVaultClient _keyVaultClient;
        private readonly IConfiguration _configuration;
        public JournalEntryService(IConfiguration configuration,KeyVaultClient keyVaultClient)
        {
            _keyVaultClient = keyVaultClient;
            _configuration = configuration;
            _textAnalyticsClient = new TextAnalyticsClient(
                new Uri(_configuration.GetSection("Secrets:TextAnalytics:Endpoint").Value),
                new AzureKeyCredential(_keyVaultClient
                    .GetSecretAsync(
                        _configuration.GetSection("Secrets:TextAnalytics:Identifier").Value)
                    .Result.Value));
            _personalizerClient = new PersonalizerClient(
                new ApiKeyServiceClientCredentials(_keyVaultClient
                    .GetSecretAsync(
                        _configuration.GetSection("Secrets:Personalizer:Identifier").Value)
                    .Result.Value))
                { Endpoint = _configuration.GetSection("Secrets:Personalizer:Endpoint").Value };

        }

        public async Task<JournalEntry> GetTextAnalytics(UserEntry userEntry)
        {
            // You will implement these methods later in the quickstart.
            Random rnd = new Random();
            JournalEntry journalEntry = new JournalEntry();
            journalEntry.JournalKey = rnd.Next(1, 100000);
            journalEntry.TimeStamped = DateTime.Now;
            journalEntry.Prompt = userEntry.Prompt;
            journalEntry.Contents = userEntry.Contents;
            journalEntry.Feeling = userEntry.Feeling;
            journalEntry.Keywords = KeyPhraseExtraction(_textAnalyticsClient,userEntry);
            double[] sentimentPercentages = SentimentAnalysisPercentages(_textAnalyticsClient, userEntry);
            journalEntry.Positive = sentimentPercentages[0];
            journalEntry.Negative = sentimentPercentages[1];
            journalEntry.Neutral = sentimentPercentages[2];

            return journalEntry;
        }

        static double[] SentimentAnalysisPercentages(TextAnalyticsClient client, UserEntry userEntry)
        {
            // don't seem to be using this right now, but might be useful (overall sentiment of entry)
            DocumentSentiment documentSentiment = client.AnalyzeSentiment(userEntry.Prompt);

            double positiveAmount = 0.0;
            double negativeAmount = 0.0;
            double neutralAmount = 0.0;
            int numSentences = 0;

            foreach (var sentence in documentSentiment.Sentences)
            {
                numSentences = numSentences + 1;
                positiveAmount = positiveAmount + sentence.ConfidenceScores.Positive;
                negativeAmount = positiveAmount + sentence.ConfidenceScores.Negative;
                neutralAmount = positiveAmount + sentence.ConfidenceScores.Neutral;
            }

            double positivePercentage = positiveAmount / numSentences;
            double negativePercentage = negativeAmount / numSentences;
            double neutralPercentage = neutralAmount / numSentences;

            double[] percentages = { positivePercentage, negativePercentage, neutralPercentage };
            return percentages;

        }

        static string KeyPhraseExtraction(TextAnalyticsClient client, UserEntry userEntry)
        {
            var response = client.ExtractKeyPhrases(userEntry.Prompt);
            string keywords = string.Join(",", response.Value);
            return keywords;
        }

        public async Task<IEnumerable<string>> GetBestGoals(IEnumerable<Goal> inputGoals, UserData user, int mood)
        {
            string eventId = Guid.NewGuid().ToString();
            List<string> goals = new List<string>();
            IList<object> currentContext = new List<object>()
            {
                new{ Mood = mood},
                new{ Feeling = user.MentalHealth}
            };
            IList<RankableAction> rankActions = new List<RankableAction>();
            foreach(Goal goal in inputGoals)
            {
                rankActions.Add(new RankableAction
                {
                    Id = goal.GoalText,
                    Features = new List<object>()
                    {
                        new {goal.Mood},
                        new {goal.Feeling},
                        new {goal.Intensity}
                    }
                });
            }
            RankRequest rank = new RankRequest(rankActions, currentContext, default, eventId);
            var result = await _personalizerClient.RankAsync(rank);
            for(int i =0; i<3 && i<result.Ranking.Count(); i++)
            {
                goals.Add(result.Ranking[i].Id);
            }


            return goals;
        }

        public async Task<IEnumerable<string>> GetBestPrompts(IEnumerable<Prompt> inputPrompts, UserData user, int mood)
        {
            string eventId = Guid.NewGuid().ToString();
            List<string> prompts = new List<string>();
            IList<object> currentContext = new List<object>()
            {
                new{ Mood = mood},
                new{ Feeling = user.MentalHealth}
            };
            IList<RankableAction> rankActions = new List<RankableAction>();
            foreach (Prompt prompt in inputPrompts)
            {
                rankActions.Add(new RankableAction
                {
                    Id = prompt.PromptText,
                    Features = new List<object>()
                    {
                        new {prompt.Mood},
                        new {prompt.Feeling},
                        new {prompt.Intensity}
                    }
                });
            }
            RankRequest rank = new RankRequest(rankActions, currentContext, default, eventId);
            var result = await _personalizerClient.RankAsync(rank);
            for (int i = 0; i < 3 && i < result.Ranking.Count(); i++)
            {
                prompts.Add(result.Ranking[i].Id);
            }


            return prompts;
        }
    }

}
