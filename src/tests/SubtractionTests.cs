using Kaleidocode.Katas.Libraries.StringCalculator.Helpers;
using Kaleidocode.Katas.Tests.Contracts;
using Kaleidocode.Katas.Tests.Fixtures;

namespace Kaleidocode.Katas.Tests;

public class SubtractionTests(SubtractionFixture fixture) : IClassFixture<SubtractionFixture>
{
    private readonly IFixture _fixture = fixture;

    [Theory]
    [InlineData("", 0)]
    public void Given_UserProvidesNoInput_When_Validates_Returns_Zero(string userInput, int expectedValue)
    {
        // Given
        _fixture.SetInputValue(userInput);
        _fixture.SetTestCondition(input => input > 1000);

        // When
        bool successful = _fixture.Validate();
        int subtractedValues = ArithmeticHelper.Subtract(_fixture.GetCollectedValues());

        // Then
        Assert.Equal(expectedValue, subtractedValues);
    }

    [Theory]
    [InlineData("a,b", -1)]
    [InlineData("b&c", -3)]
    [InlineData("i\\rj&&-**k", -17)]
    [InlineData("a\\0-e", -4)]
    [InlineData("0;\\t-12<>49", -61)]
    [InlineData("10\\n\\s19", -29)]
    [InlineData("f\\-79,902&&12", -998)]
    public void Given_UserProvidesNumbers_When_Validated_IsEqual(string userInput, int expectedValue)
    {
        // Given
        _fixture.SetInputValue(userInput);
        _fixture.SetTestCondition(input => input > 1000);

        // When
        bool successful = _fixture.Validate();
        int subtractedValues = ArithmeticHelper.Subtract(_fixture.GetCollectedValues());

        // Then
        Assert.Equal(expectedValue, subtractedValues);
    }

    [Theory]
    [InlineData("e\\-293&&29384--90|123", true)]
    public void Given_UserProvidesInput_When_Validated_Fails_With_Message(string userInput, bool errorMessageRendered)
    {
        string? errorMessage = string.Empty;

        try
        {
            // Given
            _fixture.SetInputValue(userInput);
            _fixture.SetTestCondition(input => input > 1000);

            // When
            bool successful = _fixture.Validate();
            int subtractedValues = ArithmeticHelper.Subtract(_fixture.GetCollectedValues());
        }
        catch (Exception ex)
        {
            errorMessage = ex.Message;
        }

        // Then
        Assert.Equal(errorMessageRendered, !string.IsNullOrEmpty(errorMessage));
    }

}
