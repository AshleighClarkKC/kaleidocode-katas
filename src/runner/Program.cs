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
                
                try
                {
                    IngestInput(sumNumberInput.Value, sumNumberInput.ErrorMessage);
                }
                catch(ArgumentOutOfRangeException oor)
                {
                    Console.WriteLine($"\nERROR: {oor.Message}\n");
                }

                Console.WriteLine("\nYou will now be redirected back to the initial menu.\n");

                break;
            }
        case (int)UserOption.Exit: { break; }
        default: { break; }
    }
}
while (!userChoice.Equals((int)UserOption.Exit));