using Kaleidocode.Katas.Libraries.Contracts;
using Kaleidocode.Katas.Libraries.StringCalculator.Enumerations;
using Kaleidocode.Katas.Libraries.StringCalculator.Parsers;
using Kaleidocode.Katas.Libraries.StringCalculator.Templates;
using Kaleidocode.Katas.Libraries.StringCalculator.Validators;
using Kaleidocode.Katas.Tests.Contracts;

namespace Kaleidocode.Katas.Tests.Fixtures
{
    public class SubtractionFixture : IFixture, IDisposable
    {
        private readonly IValidator _inputValidator;

        private readonly IParser _inputParser;

        private IEnumerable<int> CollectedValues { get; set; } = [];

        public SubtractionFixture()
        {
            _inputParser = new InputParser(string.Empty);
            _inputValidator = new OperationValidator(CollectedValues, null);
        }

        public void SetTestCondition(Func<int, bool> condition)
            => _inputValidator.SetValidationCondition(condition);

        public void SetInputValue(string inputValue)
            => _inputParser.SetInputValue(inputValue);

        public IEnumerable<int> GetCollectedValues()
            => CollectedValues;

        public bool Validate()
        {
            CollectedValues = _inputParser.CollectNumbers(ExtractionMethod.Alphanumeric);
            _inputValidator.SetInputCollection(CollectedValues);
            return _inputValidator.Validate(input => MessageTemplates.GenerateErrorString(ErrorCondition.NumbersExceedingLimit, input));
        }

        public void Dispose()
        {
            CollectedValues = [];
            GC.SuppressFinalize(this);
        }
    }
}
