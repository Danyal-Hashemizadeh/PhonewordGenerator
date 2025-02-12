using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhonewordGenerator.BLM
{
    // Class to filter and rank phonewords using a dictionary and custom words
    public class WordMatcher
    {
        private HashSet<string> _dictionary; // Set of dictionary words
        private HashSet<string> _customWords; // Set of custom words from input

        // Constructor initializing the dictionaries
        public WordMatcher(IEnumerable<string> dictionary, IEnumerable<string> customWords)
        {
            _dictionary = new HashSet<string>(dictionary);
            _customWords = new HashSet<string>(customWords);
        }

        // Filters and ranks phonewords based on meaningfulness
        public List<string> FilterAndRankPhonewords(List<string> phonewords, CancellationToken token)
        {
            var validPhonewords = new List<PhonewordInfo>();

            foreach (var phoneword in phonewords)
            {
                token.ThrowIfCancellationRequested();

                var parts = phoneword.Split('-');
                int totalPartitions = parts.Length;
                int meaningfulPartitions = 0;
                int totalMeaningfulLength = 0;
                bool isWholeWordMatch = false;

                foreach (var part in parts)
                {
                    // Check if part is a meaningful word
                    if (_dictionary.Contains(part) || _customWords.Contains(part))
                    {
                        meaningfulPartitions++;
                        totalMeaningfulLength += part.Length;
                    }
                }

                // Check if the entire phoneword is a whole word match
                if (meaningfulPartitions == 1 && totalPartitions == 1)
                {
                    isWholeWordMatch = true;
                }

                if (meaningfulPartitions > 0)
                {
                    // Add phoneword info for ranking
                    validPhonewords.Add(new PhonewordInfo
                    {
                        Phoneword = phoneword,
                        TotalPartitions = totalPartitions,
                        MeaningfulPartitions = meaningfulPartitions,
                        TotalMeaningfulLength = totalMeaningfulLength,
                        IsWholeWordMatch = isWholeWordMatch
                    });
                }
            }

            // rank the results based on the criteria
            var rankedResults = validPhonewords
                .OrderByDescending(pw => pw.IsWholeWordMatch)              // Whole-word matches first
                .ThenBy(pw => pw.TotalPartitions)                          // Fewer partitions preferred
                .ThenByDescending(pw => pw.TotalMeaningfulLength)          // Longer meaningful words
                .ThenByDescending(pw => pw.MeaningfulPartitions)           // More meaningful partitions
                .Select(pw => pw.Phoneword)
                .ToList();

            return rankedResults;
        }

        // Private class to hold phoneword information for ranking
        private class PhonewordInfo
        {
            public string Phoneword { get; set; }
            public int TotalPartitions { get; set; }
            public int MeaningfulPartitions { get; set; }
            public int TotalMeaningfulLength { get; set; }
            public bool IsWholeWordMatch { get; set; }
        }
    }
}
