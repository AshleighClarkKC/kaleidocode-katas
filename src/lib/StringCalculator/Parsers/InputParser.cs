using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaleidocode.Katas.Libraries.StringCalculator.Parsers
{
    /// <summary>
    /// Responsible for converting the string input provided by <see cref="Console.ReadLine" />.
    /// </summary>
    /// <param name="userInput">The input received from stdin (<see cref="Console.ReadLine">).</param>
    public class InputParser(string? userInput)
    {
        public string? UserInput { get; init; } = userInput ?? string.Empty;

        /// <summary>
        /// Filters out numbers from the delimiters since they do not need to be uniform.
        /// </summary>
        /// <returns>Returns a list of numbers that are unsanitized.</returns>
        public IEnumerable<int> CollectNumbers()
        {
            List<int> collectedNumbers = [];

            if (string.IsNullOrWhiteSpace(UserInput)) { return [0]; }

            StringBuilder sb = new ();

            for (int iterator = 0; iterator < UserInput.Length; iterator++)
            {
                char focusedCharacter = UserInput[iterator];

                if (focusedCharacter.Equals('-') || int.TryParse(focusedCharacter.ToString(), out _))
                {
                    sb.Append(focusedCharacter);
                }
                else
                {
                    if (!(sb[sb.Length - 1].Equals(',')))
                    {
                        sb.Append(',');
                    }
                }
            }

            var numberSample = (sb.ToString())
                .Split(',')
                .Select(s => int.Parse(s));

            collectedNumbers.AddRange(numberSample);

            return collectedNumbers;
        }
    }
}
