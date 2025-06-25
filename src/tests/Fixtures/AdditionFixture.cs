using Kaleidocode.Katas.Libraries.Contracts;
using Kaleidocode.Katas.Libraries.StringCalculator.Enumerations;
using Kaleidocode.Katas.Libraries.StringCalculator.Parsers;
using Kaleidocode.Katas.Libraries.StringCalculator.Templates;
using Kaleidocode.Katas.Libraries.StringCalculator.Validators;
using Kaleidocode.Katas.Tests.Contracts;

namespace Kaleidocode.Katas.Tests.Fixtures
{
    public class AdditionFixture : IFixture, IDisposable
    {
        private readonly IValidator _inputValidator;

        private readonly IParser _inputParser;

        private IEnumerable<int> CollectedValues { get; set; } = [];

        public AdditionFixture()
        {
            _inputParser = new InputParser(string.Empty);
            _inputValidator = new OperationValidator(CollectedValues, null);
        }

        public void SetTestCondition(Func<int, bool> testCondition)
            => _inputValidator.SetValidationCondition(testCondition);

        public void SetInputValue(string value) 
            => _inputParser.SetInputValue(value);

        public IEnumerable<int> GetCollectedValues() 
            => CollectedValues;

        public bool Validate()
        {
            CollectedValues = _inputParser.CollectNumbers(ExtractionMethod.StrictNumeric);
            _inputValidator.SetInputCollection(CollectedValues);
            return _inputValidator.Validate(input => MessageTemplates.GenerateErrorString(ErrorCondition.NegativeValuesNotAllowed, input));
        }

        public void Dispose() 
        {
            CollectedValues = [];
            GC.SuppressFinalize(this);
        }
    }
}
