namespace Kaleidocode.Katas.Runner.Utilities;

using Kaleidocode.Katas.Libraries.Contracts;
using Kaleidocode.Katas.Libraries.StringCalculator.Enumerations;
using Kaleidocode.Katas.Libraries.StringCalculator.Helpers;
using Kaleidocode.Katas.Libraries.StringCalculator.Templates;
using Kaleidocode.Katas.Libraries.StringCalculator.Validators;
using Kaleidocode.Katas.Runner.Enumerations;
using static System.Console;

public class ConsoleOutput
{
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
        "3. Exit the Application."
    ];

    public static void PrintOptions()
    {
        WriteLine(Environment.NewLine);
        foreach (string option in UserOptions)
        {
            WriteLine(option);
        }
        WriteLine(Environment.NewLine);
    }

    public static int ProvideUserSelection()
    {
        WriteLine(GetSeparator(true));
        Write("\nYour Option: ");
        string? userRawSelection = ReadLine();
        bool selectionValid = int.TryParse(userRawSelection, out var userSelectedValue);
        WriteLine($"\n{GetSeparator(true)}");

        return selectionValid ? userSelectedValue : -1;
    }

    public static void PrintStringCalculatorEntryPrompt(UserOption selectedOption)
    {
        WriteLine($"\nSelected Function: {GetHumanReadableOperationName(selectedOption)}");
        WriteLine("Please enter a string list with separators.");
        WriteLine("e.g. 28,87,1983,9986 or 982\\n83672\\n992");
    }

    private static string GetHumanReadableOperationName(UserOption userOption)
        => userOption switch
        {
            UserOption.AdditionCalculator => "Addition",
            UserOption.SubtractionCalculator => "Subtraction",
            _ => throw new ArgumentOutOfRangeException(paramName: Enum.GetName<UserOption>(userOption))
        };

    public static IEnumerable<int> ProvideUserInputSection(IParser parser, ExtractionMethod extractionMethod)
    {
        WriteLine("Your Input -> ");
        string? userInput = ReadLine() ?? string.Empty;
        parser.SetInputValue(userInput);
        return parser.CollectNumbers(extractionMethod);
    }

    public static void PrintValue(int? value)
    {
        WriteLine($"\nSum of your input: {value}.\n");
    }

    public static void HandleOperation(
        IEnumerable<int> parsedNumbers, 
        IValidator validator, 
        ErrorCondition errorCondition, 
        UserOption userOption)
    {
        try
        {
            switch (userOption)
            {
                case UserOption.AdditionCalculator:
                    {
                        bool evaluationSuccessful = validator.Validate(
                            errorMessageTemplate: input => MessageTemplates.GenerateErrorString(errorCondition, input)
                        );

                        if (evaluationSuccessful)
                        {
                            int sumOfNumbersInCollection = ArithmeticHelper.Add(parsedNumbers);
                            PrintValue(sumOfNumbersInCollection);
                        }

                        break;
                    }
                case UserOption.SubtractionCalculator:
                    {
                        bool evaluationSuccessful = validator.Validate(
                            errorMessageTemplate: input => MessageTemplates.GenerateErrorString(errorCondition, input)
                        );

                        if (evaluationSuccessful)
                        {
                            int sumOfNumbersInCollection = ArithmeticHelper.Subtract(parsedNumbers);
                            PrintValue(sumOfNumbersInCollection);
                        }

                        break;
                    }
                default: { break; }
            }



        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nERROR: {ex.Message}\n");
        }
    }

}
