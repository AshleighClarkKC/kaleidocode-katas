using Kaleidocode.Katas.Libraries.StringCalculator.Helpers;
using Kaleidocode.Katas.Tests.Contracts;
using Kaleidocode.Katas.Tests.Fixtures;

namespace Kaleidocode.Katas.Tests;

public class AdditionTests(AdditionFixture fixture) : IClassFixture<AdditionFixture>
{
    private readonly IFixture _fixture = fixture;

    [Theory]
    [InlineData("", 0)]
    public void UserInput_EmptyString(string userInput, int expectedValue)
    {
        AddNumbers(userInput, expectedValue);
    }

    [Theory]
    [InlineData("12", 12)]
    [InlineData("12,9478", 12)]
    [InlineData("19387\nsd029302\nse2013\nad972,127%\ran63à=192|1928&112", 1466)]
    public void UserInput_ValuesAdded(string userInput, int expectedNumber)
    {
        AddNumbers(userInput, expectedNumber);
    }

    [Theory]
    [InlineData("92783,-1230,10382,-29038,102832", true)]
    public void UserInput_NegativeValuesInCollection(string userInput, bool errorMessageExpected)
    {
        try
        {
            _fixture.SetInputValue(userInput);
            _fixture.SetTestCondition(input => int.IsNegative(input));
            bool successful = _fixture.Validate();

            int addedValues = ArithmeticHelper.Add(_fixture.GetCollectedValues());
        }
        catch (Exception ex)
        {
            Assert.Equal(!string.IsNullOrEmpty(ex.Message), errorMessageExpected);
        }
    }

    private void AddNumbers(string input, int expected)
    {
        _fixture.SetInputValue(input);
        _fixture.SetTestCondition(input => int.IsNegative(input));
        bool successful = _fixture.Validate();

        int addedValues = ArithmeticHelper.Add(_fixture.GetCollectedValues());
        Assert.Equal(expected, addedValues);
    }
}