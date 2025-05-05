using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kaleidocode.Katas.Libraries.Contracts;

namespace Kaleidocode.Katas.Libraries.StringCalculator.Validators
{
    public class AdditionValidator(IEnumerable<int>? parsedInputCollection, Func<int, bool> failureCondition) : IValidator
    {
        private IEnumerable<int> UserInputCollection { get; init; } = parsedInputCollection ?? [];

        public bool Validate()
        {
            string incompatibleNumberStringCollection = CollectIncompatibleValues(UserInputCollection, failureCondition);

            if (!string.IsNullOrEmpty(incompatibleNumberStringCollection))
            {
                string errMessage = $"Negative numbers not allowed. Incompatible values: \"{incompatibleNumberStringCollection}\".";

                throw new ArgumentOutOfRangeException(
                    paramName: nameof(UserInputCollection),
                    message: errMessage
                );
            }

            return string.IsNullOrEmpty(incompatibleNumberStringCollection);

        }

        public string CollectIncompatibleValues(IEnumerable<int> parsedNumbers, Func<int, bool> failureCondition) 
        {
            List<int> matchedValues = [];

            foreach (int iteratedValue in parsedNumbers) 
            {
                if (failureCondition.Invoke(iteratedValue)) 
                {
                    matchedValues.Add(iteratedValue);
                }
            }

            return (matchedValues.Count > 0) 
                ? string.Join(',', matchedValues)
                : string.Empty;
        }

    }
}
