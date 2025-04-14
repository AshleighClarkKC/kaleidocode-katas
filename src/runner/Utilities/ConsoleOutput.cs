namespace Kaleidocode.Katas.Runner.Utilities;

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
        "1. Use a Simple Addition Function.",
        "2. Exit the Application."
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

    public static void PrintStringCalculatorEntryPrompt()
    {
        WriteLine("\nSelected Function: String Calculator");
        WriteLine("Please enter a string list with a uniform separator.");
        WriteLine("e.g. 28,87,1983,9986 or 982\\n83672\\n992");
    }

    public static string? ProvideUserInputSection()
    {
        WriteLine("Your Input -> ");
        return ReadLine();
    }

}
