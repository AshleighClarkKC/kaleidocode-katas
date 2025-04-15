namespace Kaleidocode.Katas.Tests;

using Kaleidocode.Katas.Libraries.StringCalculator.Extensions;

public class InputExtensionTests
{
    [Theory]
    [InlineData("", 0)]
    public void UserInput_EmptyString(string userInput, int expectedValue)
    {
        var collectedValues = userInput.SumUserInput();

        Assert.Equal(expectedValue, collectedValues.Value);
    }

    [Theory]
    [InlineData("12", 12)]
    [InlineData("12,9478", 12)]
    [InlineData("19387\nsd029302\nse2013\nad972,127%\ran63à=192|1928&112", 1466)]
    public void UserInput_ValuesAdded(string? userInput, int expectedNumber)
    {
        var collectedValue = userInput.SumUserInput();

        Assert.Equal(expectedNumber, collectedValue.Value);
    }

    [Theory]
    [InlineData("92783,-1230,10382,-29038,102832", false)]
    public void UserInput_NegativeValuesInCollection(string userInput, bool errorMessageExpected)
    {
        var collectedValue = userInput.SumUserInput();

        Assert.Equal(errorMessageExpected, string.IsNullOrEmpty(collectedValue.ErrorMessage));
    }
}