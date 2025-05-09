using Kaleidocode.Katas.Libraries.StringCalculator.Helpers;
using Kaleidocode.Katas.Tests.Contracts;
using Kaleidocode.Katas.Tests.Fixtures;

namespace Kaleidocode.Katas.Tests
{
    public class SubtractionTests(SubtractionFixture fixture) : IClassFixture<SubtractionFixture>
    {
        private readonly IFixture _fixture = fixture;

        [Theory]
        [InlineData("", 0)]
        public void UserInput_EmptyString(string userInput, int expectedValue)
        {
            SubtractNumbers(userInput, expectedValue);
        }

        [Theory]
        [InlineData("a,b", -1)]
        [InlineData("b&c", -3)]
        [InlineData("i\\rj&&-**k", -17)]
        [InlineData("a\\0-e", -4)]
        [InlineData("0;\\t-12<>49", -61)]
        [InlineData("10\\n\\s19", -29)]
        [InlineData("f\\-79,902&&12", -998)]
        //[InlineData()]
        public void UserInput_SimpleEntry(string userInput, int expectedValue)
        {
            SubtractNumbers(userInput, expectedValue);
        }

        [Theory]
        [InlineData("e\\-293&&29384--90|123", true)]
        public void UserInput_ExceededLimit(string userInput, bool errorMessageRendered)
        {
            var expectedErrorMessage = SubtractNumbersWithError(userInput);
            Assert.Equal(errorMessageRendered, !string.IsNullOrEmpty(expectedErrorMessage));
        }

        private void SubtractNumbers(string input, int expected)
        {
            _fixture.SetInputValue(input);
            _fixture.SetTestCondition(input => input > 1000);
            bool successful = _fixture.Validate();

            int subtractedValues = ArithmeticHelper.Subtract(_fixture.GetCollectedValues());
            Assert.Equal(expected, subtractedValues);
        }

        private string SubtractNumbersWithError(string input)
        {
            string? errorMessage = string.Empty;

            try
            {
                _fixture.SetInputValue(input);
                _fixture.SetTestCondition(input => input > 1000);
                bool successful = _fixture.Validate();
                int subtractedValues = ArithmeticHelper.Subtract(_fixture.GetCollectedValues());
            }
            catch (Exception ex) 
            {
                errorMessage = ex.Message;
            }

            return errorMessage;
        }

    }
}
