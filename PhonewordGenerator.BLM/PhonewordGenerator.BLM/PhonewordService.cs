using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhonewordGenerator.BLM
{
    // class to generate and process phonewords
    public class PhonewordService

    {
        // Property to indicate if the generation limit was reached
        public bool GenerationLimitReached { get; private set; }

        // Generates phonewords and filters them using dictionary and custom words
        public List<string> GeneratePhonewords(string number, IEnumerable<string> dictionary, IEnumerable<string> customWords, CancellationToken token)
        {
            token.ThrowIfCancellationRequested();

            var generator = new PhonewordGenerator();
            var phonewords = generator.GeneratePhonewords(number, token);// Generate phonewords

            // Update the GenerationLimitReached property
            GenerationLimitReached = generator.GenerationLimitReached;

            token.ThrowIfCancellationRequested();

            var matcher = new WordMatcher(dictionary, customWords);
            var validPhonewords = matcher.FilterAndRankPhonewords(phonewords, token);

            return validPhonewords;
        }

        // Converts a word into its numerical representation
        public string ReverseSearch(string word)
        {
            word = word.ToUpperInvariant();
            var number = "";

            foreach (char c in word)
            {
                // Find the digit that corresponds to the character
                foreach (var pair in DigitLetterMapping.GetMapping())
                {
                    if (pair.Value.Contains(c))
                    {
                        number += pair.Key;// Append the digit
                        break;
                    }
                }
            }

            return number;
        }
    }
}
