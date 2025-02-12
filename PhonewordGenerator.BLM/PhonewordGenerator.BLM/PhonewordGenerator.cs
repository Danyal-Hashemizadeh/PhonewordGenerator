using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhonewordGenerator.BLM
{
    // Class to generate phonewords from a phone number
    public class PhonewordGenerator

    {
        public const int MaxCombinations = 500000; // Maximum allowed combinations
        private int _currentCombinationCount = 0;  // Counter for generated combinations
        private bool _generationLimitReached = false;// Flag to check if limit is reached

        // Property to check if generation limit is reached
        public bool GenerationLimitReached => _currentCombinationCount >= MaxCombinations;

        // Main method to generate phonewords with cancellation support
        public List<string> GeneratePhonewords(string number, CancellationToken token)
        {
            _currentCombinationCount = 0; //Reset counter
            _generationLimitReached = false; // Reset the flag at the beginning

            token.ThrowIfCancellationRequested();

            var partitionGenerator = new PartitionGenerator(number);
            var partitions = partitionGenerator.GeneratePartitions(token);// Generate partitions

            var phonewords = new List<string>();

            foreach (var partition in partitions)
            {
                token.ThrowIfCancellationRequested();

                var combinations = GetCombinations(partition, token); // Get combinations for partition

                // Add generated combinations to the phonewords list
                phonewords.AddRange(combinations);

                if (_generationLimitReached || _currentCombinationCount >= MaxCombinations)
                {
                    // Stop processing further partitions
                    break;
                }
            }
            // Return unique phonewords
            return phonewords.Distinct().ToList();
        }


        // Generates combinations for a partition
        private List<string> GetCombinations(List<string> partition, CancellationToken token)
        {
            token.ThrowIfCancellationRequested();

            var listsOfLetters = new List<List<string>>(); 

            foreach (string part in partition)
            {
                token.ThrowIfCancellationRequested();

                var lettersList = GetLettersForPart(part, token); // Get letters for each part
                if (lettersList.Count > 0)
                {
                    listsOfLetters.Add(lettersList);
                }
                else
                {
                    // If no letters are returned for a part, return an empty list
                    return new List<string>();
                }
            }

            // Before generating combinations, check if the limit has been reached
            if (_currentCombinationCount >= MaxCombinations)
            {
                return new List<string>(); // Return empty list to stop further processing
            }

            // Generate Cartesian product of the lists of letters
            var combinations = CartesianProduct(listsOfLetters, token);
            return combinations;
        }

        // Retrieves possible letters for a part of the partition
        private List<string> GetLettersForPart(string part, CancellationToken token)
        {
            token.ThrowIfCancellationRequested();

            var lettersList = new List<string>();

            // Handle single digit 0 or 1
            if (part.Length == 1 && (part == "0" || part == "1"))
            {
                lettersList.Add(part); // Add '0' or '1' directly
            }
            else
            {
                var charsList = new List<char[]>();

                foreach (char digit in part)
                {
                    token.ThrowIfCancellationRequested();

                    var letters = DigitLetterMapping.GetLetters(digit);
                    if (letters.Length > 0)
                    {
                        charsList.Add(letters);
                    }
                    else
                    {
                        return new List<string>(); // Invalid digit, return empty
                    }
                }

                // Generate combinations for the part
                lettersList = GenerateCombinations(charsList, token);
            }

            return lettersList;
        }

        // Generates all possible combinations of characters for a list of char arrays
        private List<string> GenerateCombinations(List<char[]> charsList, CancellationToken token)
        {
            token.ThrowIfCancellationRequested();

            var result = new List<string>() { "" }; // Start with empty string

            foreach (var letters in charsList)
            {
                token.ThrowIfCancellationRequested();

                var tempList = new List<string>();
                foreach (var prefix in result)
                {
                    foreach (var letter in letters)
                    {
                        token.ThrowIfCancellationRequested();

                        string combination = prefix + letter; // Build new combination
                        tempList.Add(combination);

                        // Increment the counter after adding the combination
                        _currentCombinationCount++;

                        if (_currentCombinationCount >= MaxCombinations)
                        {
                            // Set the generation limit reached flag
                            _generationLimitReached = true;
                            // Return the combinations generated so far
                            return tempList;
                        }
                    }
                }
                result = tempList;

                // Check after processing each set of letters
                if (_currentCombinationCount >= MaxCombinations)
                {
                    _generationLimitReached = true;
                    break;
                }
            }

            return result;
        }


        // Computes the Cartesian product of lists of strings
        private List<string> CartesianProduct(List<List<string>> lists, CancellationToken token)
        {
            token.ThrowIfCancellationRequested();

            var result = new List<string>() { "" };

            foreach (var list in lists)
            {
                token.ThrowIfCancellationRequested();

                var tempList = new List<string>();
                foreach (var prefix in result)
                {
                    foreach (var item in list)
                    {
                        token.ThrowIfCancellationRequested();

                        string combination = string.IsNullOrEmpty(prefix) ? item : prefix + "-" + item; // Combine with hyphen separator
                        tempList.Add(combination);

                        // Increment the counter after adding the combination
                        _currentCombinationCount++;

                        if (_currentCombinationCount >= MaxCombinations)
                        {
                            _generationLimitReached = true;
                            // Return the combinations generated so far
                            return tempList;
                        }
                    }
                }
                result = tempList;

                // Check after processing each list
                if (_currentCombinationCount >= MaxCombinations)
                {
                    _generationLimitReached = true;
                    break;
                }
            }

            return result;
        }


    }
}
