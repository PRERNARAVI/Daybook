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


namespace HackathonApi.Models.Service
{
    public class JournalEntryService
    {
        private readonly KeyVaultClient _keyVaultClient;
        public JournalEntryService()
        {
            
        }


        private static readonly AzureKeyCredential credentials = new AzureKeyCredential("09a6c83ffa65465bb8710e753b41da7f");
        private static readonly Uri endpoint = new Uri("https://daybooksa.cognitiveservices.azure.com/");

        public async Task<JournalEntry> GetTextAnalytics(UserEntry userEntry)
        {

            var client = new TextAnalyticsClient(endpoint, credentials);
            // You will implement these methods later in the quickstart.
            SentimentAnalysisPercentages(client, userEntry);
            KeyPhraseExtraction(client, userEntry);

            Console.Write("Press any key to exit.");
            Console.ReadKey();

            JournalEntry journalEntry = new JournalEntry();
            journalEntry.Prompt = userEntry.Prompt;
            journalEntry.Contents = userEntry.Contents;
            journalEntry.Feeling = userEntry.Feeling;
            journalEntry.Keywords = KeyPhraseExtraction(client, userEntry);
            double[] sentimentPercentages = SentimentAnalysisPercentages(client, userEntry);
            journalEntry.Positive = sentimentPercentages[0];
            journalEntry.Negative = sentimentPercentages[1];
            journalEntry.Neutral = sentimentPercentages[2];

            return new JournalEntry();
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
    }

}
