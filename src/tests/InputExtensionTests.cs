using Kaleidocode.Katas.Libraries.StringCalculator.Helpers;
using Kaleidocode.Katas.Libraries.StringCalculator.Parsers;
using Kaleidocode.Katas.Libraries.StringCalculator.Validators;

namespace Kaleidocode.Katas.Tests;


public class InputExtensionTests
{
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
            var ip = new InputParser(userInput);
            var collectedValues = ip.CollectNumbers();

            var iv = new InputValidator(collectedValues);
            bool successful = iv.EvaluateCollection();

            var ah = new ArithmeticHelper();
            int addedValues = ah.Add(collectedValues);
        }
        catch (Exception ex)
        {
            Assert.Equal(!string.IsNullOrEmpty(ex.Message), errorMessageExpected);
        }
    }

    private void AddNumbers(string input, int expected)
    {
        var ip = new InputParser(input);
        var collectedValues = ip.CollectNumbers();

        var iv = new InputValidator(collectedValues);
        bool successful = iv.EvaluateCollection();

        var ah = new ArithmeticHelper();
        int addedValues = ah.Add(collectedValues);
        Assert.Equal(expected, addedValues);
    }
}