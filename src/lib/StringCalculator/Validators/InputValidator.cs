using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaleidocode.Katas.Libraries.StringCalculator.Validators
{
    /// <summary>
    /// Rule checker for number collections parsed from stdin.
    /// </summary>
    /// <param name="parsedInputCollection">The collection to be validated.</param>
    public class InputValidator(IEnumerable<int>? parsedInputCollection)
    {
        private IEnumerable<int> UserInputCollection { get; init; } = parsedInputCollection ?? [];

        /// <summary>
        /// Initialize the validation process. 
        /// </summary>
        /// <returns>Returns whether the process was successful or not.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when there is a value (or values) that is/are negative.</exception>
        public bool EvaluateCollection()
        {
            List<int> incompatibleNumbers = [];

            foreach (int iteratedValue in UserInputCollection)
            {
                if (!int.IsPositive(iteratedValue))
                {
                    incompatibleNumbers.Add(iteratedValue);
                }
            }

            string incompatibleNumberStringCollection = string.Join(',', incompatibleNumbers);

            if (incompatibleNumbers.Count > 0)
            {
                string errMessage = $"Negative numbers not allowed. Incompatible values: \"{incompatibleNumberStringCollection}\".";

                throw new ArgumentOutOfRangeException(
                    paramName: nameof(UserInputCollection),
                    message: errMessage
                );
            }

            return incompatibleNumbers.Count.Equals(0);

        }

    }
}
