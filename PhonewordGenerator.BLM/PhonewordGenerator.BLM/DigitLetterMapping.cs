namespace PhonewordGenerator.BLM
{
    public static class DigitLetterMapping     // Static class to map digits to letters
    {
        // Dictionary mapping each digit to its corresponding letters
        private static readonly Dictionary<char, char[]> _digitToLetters = new Dictionary<char, char[]>
        {
            { '0', new char[] { '0' } },
            { '1', new char[] { '1' } },
            { '2', new char[] { 'A', 'B', 'C' } },
            { '3', new char[] { 'D', 'E', 'F' } },
            { '4', new char[] { 'G', 'H', 'I' } },
            { '5', new char[] { 'J', 'K', 'L' } },
            { '6', new char[] { 'M', 'N', 'O' } },
            { '7', new char[] { 'P', 'Q', 'R', 'S' } },
            { '8', new char[] { 'T', 'U', 'V' } },
            { '9', new char[] { 'W', 'X', 'Y', 'Z' } },
        };

        // Retrieves the letters corresponding to a given digit
        public static char[] GetLetters(char digit)
        {
            if (_digitToLetters.ContainsKey(digit))
            {
                return _digitToLetters[digit]; //Return the associated letters
            }
            else
            {
                return new char[] { }; // Return empty array if digit not found
            }
        }
        // Retrieves the entire digit-to-letters mapping dictionary
        public static Dictionary<char, char[]> GetMapping()
        {
            return _digitToLetters;
        }
    }
}
