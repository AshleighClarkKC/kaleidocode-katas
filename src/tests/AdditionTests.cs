using Kaleidocode.Katas.Libraries.StringCalculator.Helpers;
using Kaleidocode.Katas.Libraries.StringCalculator.Parsers;
using Kaleidocode.Katas.Libraries.StringCalculator.Validators;
using Kaleidocode.Katas.Tests.Contracts;
using Kaleidocode.Katas.Tests.Fixtures;

namespace Kaleidocode.Katas.Tests;

public class AdditionTests()
{
    /**
     * Note: Changed IFixture -> AdditionFixture due to CA1859 (Performance)
     * Note: AdditionTests not inheriting from IClassFixture<AdditionalFixture> due to custom ctor structure.
     */
    private readonly AdditionFixture Fixture = new (input => int.IsNegative(input));

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
            Fixture.SetInputValue(userInput);
            bool successful = Fixture.Validate();

            var ah = new ArithmeticHelper();
            int addedValues = ah.Add(Fixture.GetCollectedValues());
        }
        catch (Exception ex)
        {
            Assert.Equal(!string.IsNullOrEmpty(ex.Message), errorMessageExpected);
        }
    }

    private void AddNumbers(string input, int expected)
    {
        Fixture.SetInputValue(input);
        bool successful = Fixture.Validate();

        var ah = new ArithmeticHelper();
        int addedValues = ah.Add(Fixture.GetCollectedValues());
        Assert.Equal(expected, addedValues);
    }
}