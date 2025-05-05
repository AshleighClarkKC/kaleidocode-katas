using Kaleidocode.Katas.Runner.Enumerations;
using static Kaleidocode.Katas.Runner.Utilities.ConsoleOutput;
using Kaleidocode.Katas.Libraries.StringCalculator.Parsers;
using Kaleidocode.Katas.Libraries.StringCalculator.Validators;
using Kaleidocode.Katas.Libraries.StringCalculator.Helpers;
using Kaleidocode.Katas.Libraries.Contracts;
using Kaleidocode.Katas.Libraries.StringCalculator.Enumerations;


int userChoice;
IValidator inputValidator;

do
{
    PrintWelcome();
    PrintOptions();
    userChoice = ProvideUserSelection();

    switch (userChoice) 
    {
        case (int)UserOption.AdditionCalculator:
            {
                PrintStringCalculatorEntryPrompt();
                string? delimitedNumbers = ProvideUserInputSection();
                
                try
                {
                    InputParser numParser = new (delimitedNumbers);
                    IEnumerable<int> collectedNumbers = numParser.CollectNumbers(ExtractionMethod.StrictNumeric);
                    inputValidator = new AdditionValidator(collectedNumbers, i => int.IsNegative(i));

                    bool evaluationSuccessful = inputValidator.Validate();

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
        case (int)UserOption.SubtractionCalculator:
            {
                break;
            }
        case (int) UserOption.Exit: { break; }
        default: { break; }
    }
}
while (!userChoice.Equals((int) UserOption.Exit));