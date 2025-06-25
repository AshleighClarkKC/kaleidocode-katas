using Kaleidocode.Katas.Libraries.Contracts;
using Kaleidocode.Katas.Libraries.StringCalculator.Enumerations;
using Kaleidocode.Katas.Libraries.StringCalculator.Helpers;
using Kaleidocode.Katas.Libraries.StringCalculator.Templates;
using Kaleidocode.Katas.Runner.Constants;
using Kaleidocode.Katas.Runner.Enumerations;
using Microsoft.Extensions.Configuration;
using static System.Console;

namespace Kaleidocode.Katas.Runner.Utilities;

public class ConsoleOutput
{
    #region Printing Values & Options

    public static void PrintWelcome()
    {
        WriteLine(GetSeparator(true));
        WriteLine("\nWelcome to the Kaleidocode Katas.");
        WriteLine("To run one of the Katas, please select from the options below:\n");
        WriteLine(GetSeparator(true));
    }

    private static string GetSeparator(bool doubleLine = false)
        => doubleLine
            ? "==============================================================="
            : "---------------------------------------------------------------";

    private static string[] UserOptions =>
    [
        "1. Add Some Values.",
        "2. Subtract Some Values.",
        "3. Read a File and Arrange Values.",
        "4. Exit the Application."
    ];

    private static string GetHumanReadableOperationName(UserOption userOption)
       => userOption switch
       {
           UserOption.AdditionCalculator => "Addition",
           UserOption.SubtractionCalculator => "Subtraction",
           UserOption.FileReader => "File Reader",
           _ => throw new ArgumentOutOfRangeException(paramName: Enum.GetName<UserOption>(userOption))
       };

    public static void PrintOptions()
    {
        WriteLine(Environment.NewLine);
        foreach (string option in UserOptions)
        {
            WriteLine(option);
        }
        WriteLine(Environment.NewLine);
    }

    public static void PrintStringCalculatorEntryPrompt(UserOption selectedOption)
    {
        WriteLine($"\nSelected Function: {GetHumanReadableOperationName(selectedOption)}");
        WriteLine("Please enter a string list with separators.");
        WriteLine("e.g. 28,87,1983,9986 or 982\\n83672\\n992");
    }

    public static void PrintSumOfInput(int? value)
    {
        WriteLine($"\nSum of your input: {value}.\n");
    }

    public static void PrintReaderOperationExplanation()
    {
        WriteLine($"\n{GetSeparator(true)}\nSelected Function: {GetHumanReadableOperationName(UserOption.FileReader)}");
        WriteLine($"A File will be read back to you with a count of unique characters since the 1st repeated character\n{GetSeparator()}");
    }

    public static void PrintCollectionData(string[] dataCollection)
    {
        foreach(string data in dataCollection)
        {
            WriteLine(data);
        }

        WriteLine($"\n{GetSeparator()}\n");
    }

    #endregion

    #region Get User Input

    public static int ProvideUserSelection()
    {
        WriteLine(GetSeparator(true));
        Write("\nYour Option: ");
        string? userRawSelection = ReadLine();
        bool selectionValid = int.TryParse(userRawSelection, out var userSelectedValue);
        WriteLine($"\n{GetSeparator(true)}");

        return selectionValid ? userSelectedValue : -1;
    }

    public static IEnumerable<int> GetUserInputForNumericConversion(INumericParser parser, ExtractionMethod extractionMethod)
    {
        WriteLine("Your Input -> ");
        string? userInput = ReadLine() ?? string.Empty;
        parser.SetInputValue(userInput);
        return parser.CollectValues(extractionMethod);
    }

    #endregion


    public static void HandleOperation(
        IEnumerable<int> parsedNumbers, 
        IValidator validator, 
        ErrorCondition errorCondition, 
        UserOption userOption,
        IConfiguration configuration)
    {
        try
        {
            bool evaluationSuccessful = validator.Validate(
                errorMessageTemplate: input => MessageTemplates.GenerateErrorString(errorCondition, input)
            );

            int maxValue = int.Parse(configuration[ConfigurationConstants.ADDITION_MAX_VALUE_KEY]!);

            int sumOfNumbersInCollection = userOption switch {
                UserOption.AdditionCalculator => ArithmeticHelper.Add(parsedNumbers, maxValue),
                UserOption.SubtractionCalculator => ArithmeticHelper.Subtract(parsedNumbers),
                _ => throw new ArgumentOutOfRangeException(paramName: nameof(userOption))
            };
            
            PrintSumOfInput(sumOfNumbersInCollection);
        }
        catch (Exception ex)
        {
            WriteLine($"\nERROR: {ex.Message}\n");
        }
    }

}
