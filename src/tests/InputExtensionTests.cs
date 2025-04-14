namespace Kaleidocode.Katas.Tests;

using Kaleidocode.Katas.Libraries.StringCalculator.Extensions;

public class InputExtensionTests
{
    [Fact]
    public void UserInput_EmptyString()
    {
        string? userInput = string.Empty;
        var collectedValues = userInput.SumUserInput();

        Assert.Equal(0, collectedValues.Value);
    }

    [Theory]
    [InlineData("12", 12)]
    [InlineData("12,9478", 9490)]
    [InlineData("19387\nsd029302\nse2013", 50702)]
    public void UserInput_ValuesAdded(string? userInput, int expectedNumber)
    {
        var collectedValue = userInput.SumUserInput();

        Assert.Equal(expectedNumber, collectedValue.Value);
    }

    [Fact]
    public void UserInput_NegativeValuesInCollection()
    {
        string sampleValue = "92783,-1230,10382,-29038,102832";

        var collectedValue = sampleValue.SumUserInput();

        Assert.True(!string.IsNullOrEmpty(collectedValue.ErrorMessage));
    }
}