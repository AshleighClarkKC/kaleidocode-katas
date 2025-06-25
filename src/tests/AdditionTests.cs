using Kaleidocode.Katas.Libraries.StringCalculator.Helpers;
using Kaleidocode.Katas.Tests.Contracts;
using Kaleidocode.Katas.Tests.Fixtures;

namespace Kaleidocode.Katas.Tests;

public class AdditionTests(AdditionFixture fixture) : IClassFixture<AdditionFixture>
{
    private readonly IFixture _fixture = fixture;

    [Theory]
    [InlineData("", 0)]
    public void Given_UserProvidesNoInput_When_Validated_Returns_Zero(string userInput, int expectedValue)
    {
        // Given
        _fixture.SetInputValue(userInput);
        _fixture.SetTestCondition(input => int.IsNegative(input));

        // When
        _fixture.Validate();
        int addedValues = ArithmeticHelper.Add(_fixture.GetCollectedValues(), _fixture.GetMaxValue());

        // Then
        Assert.Equal(expectedValue, addedValues);
    }

    [Theory]
    [InlineData("12", 12)]
    [InlineData("12,9478", 12)]
    [InlineData("19387\nsd029302\nse2013\nad972,127%\ran63à=192|1928&112", 1466)]
    public void Given_UserProvidesPositiveNumbers_When_Validated_IsEqual(string userInput, int expectedNumber)
    {
        // Given
        _fixture.SetInputValue(userInput);
        _fixture.SetTestCondition(input => int.IsNegative(input));

        // When
        _fixture.Validate();
        int addedValues = ArithmeticHelper.Add(_fixture.GetCollectedValues(), _fixture.GetMaxValue());

        // Then
        Assert.Equal(expectedNumber, addedValues);
    }

    [Theory]
    [InlineData("92783,-1230,10382,-29038,102832", true)]
    public void Given_UserProvidesNegativeNumbers_When_Validated_Fails_With_Message(string userInput, bool errorMessageExpected)
    {
        try
        {
            // Given
            _fixture.SetInputValue(userInput);
            _fixture.SetTestCondition(input => int.IsNegative(input));

            // When
            bool successful = _fixture.Validate();
            int addedValues = ArithmeticHelper.Add(_fixture.GetCollectedValues(), _fixture.GetMaxValue());
        }
        catch (Exception ex)
        {
            // Then
            Assert.Equal(!string.IsNullOrEmpty(ex.Message), errorMessageExpected);
        }
    }

}