using Kaleidocode.Katas.Runner.Enumerations;
using static Kaleidocode.Katas.Runner.Utilities.ConsoleOutput;
using Kaleidocode.Katas.Libraries.StringCalculator.Parsers;
using Kaleidocode.Katas.Libraries.StringCalculator.Validators;
using Kaleidocode.Katas.Libraries.StringCalculator.Helpers;

int userChoice;

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
                
                try
                {
                    InputParser numParser = new (delimitedNumbers);
                    IEnumerable<int> collectedNumbers = numParser.CollectNumbers();
                    InputValidator inputValidator = new (collectedNumbers);

                    bool evaluationSuccessful = inputValidator.EvaluateCollection();

                    if (evaluationSuccessful)
                    {
                        ArithmeticHelper ah = new ();
                        int sumOfNumbersInCollection = ah.Add(collectedNumbers);
                        PrintValue(sumOfNumbersInCollection);
                    }

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