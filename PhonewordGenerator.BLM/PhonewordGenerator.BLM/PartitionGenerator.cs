using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhonewordGenerator.BLM
{
    // Class to generate all possible partitions of a phone number
    public class PartitionGenerator
    {
        private string _number;

        // Constructor to initialize with the phone number
        public PartitionGenerator(string number)
        {
            _number = number;
        }
        // Public method to generate partitions with cancellation support
        public List<List<string>> GeneratePartitions(CancellationToken token)
        {
            var result = new List<List<string>>();
            GeneratePartitionsRecursive(_number, new List<string>(), result, token);
            return result;
        }
        // Recursive helper method to generate partitions
        private void GeneratePartitionsRecursive(string remaining, List<string> currentPartition, List<List<string>> result, CancellationToken token)
        {
            // Check if cancellation is requested
            token.ThrowIfCancellationRequested();

            if (string.IsNullOrEmpty(remaining))
            {
                //No remaining digits, add current partition to result
                result.Add(new List<string>(currentPartition));
                return;
            }

            // Handle leading 0 and 1
            if (remaining[0] == '0' || remaining[0] == '1')
            {
                // Add '0' or '1' as a single partition
                currentPartition.Add(remaining[0].ToString());
                // Recurse with the rest of the string
                GeneratePartitionsRecursive(remaining.Substring(1), currentPartition, result, token);
                // Backtrack
                currentPartition.RemoveAt(currentPartition.Count - 1);
            }
            else
            {
                // Get the length of the remaining string
                int length = remaining.Length;

                if (length >= 2)
                {
                    // Partition sizes from 2 to remaining length
                    for (int i = 2; i <= length; i++)
                    {
                        string part = remaining.Substring(0, i);
                        currentPartition.Add(part);
                        GeneratePartitionsRecursive(remaining.Substring(i), currentPartition, result, token);
                        currentPartition.RemoveAt(currentPartition.Count - 1);
                    }
                }
                else
                {
                    // If only one digit left and it's not '0' or '1', do not proceed
                    return;
                }
            }
        }

    }
}
