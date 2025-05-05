using Kaleidocode.Katas.Libraries.StringCalculator.Enumerations;
using Kaleidocode.Katas.Libraries.StringCalculator.Parsers;
using Kaleidocode.Katas.Libraries.StringCalculator.Validators;
using Kaleidocode.Katas.Tests.Contracts;

namespace Kaleidocode.Katas.Tests.Fixtures
{
    public class AdditionFixture : IFixture, IDisposable
    {
        /**
         * Note: IValidator -> AdditionValidator due to CA1859 (Performance)
         */
        AdditionValidator Validator { get; init; }

        private readonly InputParser _inputParser;

        private IEnumerable<int> CollectedValues { get; set; } = [];

        public AdditionFixture(Func<int, bool> testCondition)
        {
            _inputParser = new (string.Empty);
            Validator = new (CollectedValues, testCondition);
        }

        public void SetInputValue(string value) 
            => _inputParser.SetUserInputValue(value);

        public IEnumerable<int> GetCollectedValues() 
            => CollectedValues;

        public bool Validate()
        {
            CollectedValues = _inputParser.CollectNumbers(ExtractionMethod.StrictNumeric);
            return Validator.Validate();
        }

        public void Dispose() 
        {
            CollectedValues = [];
            GC.SuppressFinalize(this);
        }
    }
}
