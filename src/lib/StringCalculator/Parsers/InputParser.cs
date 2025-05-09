using System.Text;
using Kaleidocode.Katas.Libraries.Contracts;
using Kaleidocode.Katas.Libraries.StringCalculator.Enumerations;

namespace Kaleidocode.Katas.Libraries.StringCalculator.Parsers
{
    public class InputParser(string? userInput = null) : IParser
    {
        public string? UserInput { get; private set; } = userInput ?? string.Empty;

        public void SetInputValue(string value) 
            => UserInput = value;

        public IEnumerable<int> CollectNumbers(ExtractionMethod extractionMethod)
        {
            if (string.IsNullOrEmpty(UserInput)) { return [0]; }

            IEnumerable<int> collectedNumbers = ExtractValues(UserInput, extractionMethod);

            return collectedNumbers;
        }

        private static IEnumerable<int> ExtractValues(string input, ExtractionMethod extractionMethod)
        {
            var sb = new StringBuilder();

            for (int iterator = 0; iterator < input.Length; iterator++)
            {
                var focusedChar = input[iterator];

                switch (extractionMethod)
                {
                    case ExtractionMethod.StrictNumeric:
                        {
                            if (focusedChar.Equals('-') || int.TryParse(focusedChar.ToString(), out _))
                            {
                                sb.Append(focusedChar);
                            }
                            else
                            {
                                if (!(sb[sb.Length - 1].Equals(',')))
                                {
                                    sb.Append(',');
                                }
                            }
                            break;
                        }
                    case ExtractionMethod.Alphanumeric:
                        {
                            var currentLetterIndex = ParseCharacter(focusedChar);

                            if (int.TryParse(focusedChar.ToString(), out _) ||
                                (currentLetterIndex != null && 
                                (currentLetterIndex >= 0 && currentLetterIndex <= 9))
                            )
                            {
                                sb.Append(currentLetterIndex);
                            }
                            else
                            {
                                sb.Append(',');
                            }
                            break;
                        }
                    default:
                        {
                            throw new ArgumentException($"\"{nameof(ExtractionMethod)}\" parameter has an invalid value", nameof(extractionMethod));
                        }
                }

            }

            List<int> returnableValues = [];

            foreach (var number in sb.ToString().Split(','))
            {
                if (int.TryParse(number, out int parsedValue))
                {
                    returnableValues.Add(parsedValue);
                }
            }

            return returnableValues.AsEnumerable();
        }

        private static int? ParseCharacter(char focusedLetter)
        {

            bool isNumber = int.TryParse(focusedLetter.ToString(), out int parsedNumber);

            if (isNumber) 
            {
                return parsedNumber;
            }

            var enumerableLetterRange = Enumerable.Range('a', 26)
                .Select(s => (char)s).ToArray();

            int? matchedValueInt = null;

            for(int iterator = 0; iterator < enumerableLetterRange.Length; iterator++)
            {
                if (enumerableLetterRange[iterator] == focusedLetter)
                {
                    var el = enumerableLetterRange[iterator];
                    if (enumerableLetterRange.Contains(el))
                    {
                        matchedValueInt = iterator; 
                        break;
                    }   
                }
            }

            return matchedValueInt;
        }
    }
}
