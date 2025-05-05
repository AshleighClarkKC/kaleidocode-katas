using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kaleidocode.Katas.Libraries.StringCalculator.Enumerations;

namespace Kaleidocode.Katas.Libraries.StringCalculator.Parsers
{
    public class InputParser(string? userInput)
    {
        public string? UserInput { get; private set; } = userInput ?? string.Empty;

        public void SetUserInputValue(string value) 
            => UserInput = value;

        public IEnumerable<int> CollectNumbers(ExtractionMethod extractionMethod)
        {
            IEnumerable<int> collectedNumbers = [];

            if (string.IsNullOrWhiteSpace(UserInput)) { return [0]; }

            for (int iterator = 0; iterator < UserInput.Length; iterator++)
            {
                var iteratedChar = UserInput[iterator];

                collectedNumbers = ExtractNumbers(iteratedChar, extractionMethod);
            }

            return collectedNumbers;
        }

        private static IEnumerable<int> ExtractNumbers(char focusedChar, ExtractionMethod extractionMethod)
        {
            var sb = new StringBuilder();

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
                        if (focusedChar.Equals("-") || 
                            int.TryParse(focusedChar.ToString(), out _) || 
                            (char.GetNumericValue(focusedChar) >= 0 && char.GetNumericValue(focusedChar) <= 9))
                        {
                            sb.Append(focusedChar);
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

            yield return int.Parse(sb.ToString());
        }

    }
}
