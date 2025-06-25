using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kaleidocode.Katas.Libraries.Contracts;

namespace Kaleidocode.Katas.Libraries.StringCalculator.Validators
{
    public class OperationValidator(IEnumerable<int>? parsedInputCollection, Func<int, bool>? failureCondition = null) : IValidator
    {
        private IEnumerable<int> UserInputCollection { get; set; } = parsedInputCollection ?? [];

        private Func<int, bool>? ValidationCondition { get; set; } = failureCondition;

        public void SetValidationCondition(Func<int, bool> condition)
            => ValidationCondition = condition;

        public void SetInputCollection(IEnumerable<int> inputCollection)
            => UserInputCollection = inputCollection;

        public bool Validate(Func<string, string> errorMessageTemplate)
        {
            if (ValidationCondition == null)
            {
                throw new ArgumentNullException(
                    paramName: nameof(ValidationCondition),
                    message: $"Parameter \"{nameof(ValidationCondition)}\" is required for logic validation. If validation is not required, please disable the Validator object."
                );
            }

            string incompatibleNumberStringCollection = CollectIncompatibleValues(UserInputCollection, ValidationCondition);

            if (!string.IsNullOrEmpty(incompatibleNumberStringCollection))
            {
                string errMessage = errorMessageTemplate.Invoke(incompatibleNumberStringCollection);

                throw new ArgumentOutOfRangeException(
                    paramName: nameof(UserInputCollection),
                    message: errMessage
                );
            }

            return
            ValidationCondition != null &&
            string.IsNullOrEmpty(incompatibleNumberStringCollection);
        }

        public string CollectIncompatibleValues(IEnumerable<int> parsedValues, Func<int, bool> failureCondition) 
        {
            List<int> matchedValues = [];

            foreach (int iteratedValue in parsedValues)
            {
                if ((bool)failureCondition?.Invoke(iteratedValue)!)
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
