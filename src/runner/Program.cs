using Kaleidocode.Katas.Runner.Enumerations;
using Kaleidocode.Katas.Libraries;
using static Kaleidocode.Katas.Runner.Utilities.ConsoleOutput;
using Kaleidocode.Katas.Libraries.StringCalculator.Extensions;

int userChoice = 0;

do
{
    PrintWelcome();
    PrintOptions();
    userChoice = ProvideUserSelection();

    switch (userChoice) 
    {
        case (int)UserOption.UserCalculator:
            {
                PrintStringCalculatorEntryPrompt();
                string? delimitedNumbers = ProvideUserInputSection();
                var sumNumberInput = delimitedNumbers.SumUserInput();
                
                if (!string.IsNullOrEmpty(sumNumberInput.ErrorMessage))
                {
                    throw new ArgumentOutOfRangeException(
                        paramName: nameof(delimitedNumbers),
                        message: $"Negative values not allowed. Collected values: {sumNumberInput.ErrorMessage}"
                    );
                }
                else
                {
                    Console.WriteLine($"Negative values not allowed. Collected values: {sumNumberInput.Value}\n");
                }

                break;
            }
        case (int)UserOption.Exit: { break; }
        default: { break; }
    }
}
while (!userChoice.Equals((int)UserOption.Exit));