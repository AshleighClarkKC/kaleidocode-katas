using Kaleidocode.Katas.Runner.Enumerations;
using Kaleidocode.Katas.Runner.Utilities;
using Kaleidocode.Katas.Libraries.StringCalculator.Parsers;
using Kaleidocode.Katas.Libraries.StringCalculator.Validators;
using Kaleidocode.Katas.Libraries.Contracts;
using Kaleidocode.Katas.Libraries.StringCalculator.Enumerations;

int userChoice;
IValidator inputValidator;
IParser inputParser;

do
{
    ConsoleOutput.PrintWelcome();
    ConsoleOutput.PrintOptions();
    userChoice = ConsoleOutput.ProvideUserSelection();
    inputParser = new InputParser();

    switch (userChoice) 
    {
        case (int) UserOption.AdditionCalculator:
            {
                ConsoleOutput.PrintStringCalculatorEntryPrompt(UserOption.AdditionCalculator);
                var collectedNumbers = ConsoleOutput.ProvideUserInputSection(inputParser, ExtractionMethod.StrictNumeric);

                inputValidator = new OperationValidator(
                    parsedInputCollection: collectedNumbers,
                    failureCondition: num => int.IsNegative(num)
                );

                ConsoleOutput.HandleOperation(
                    parsedNumbers: collectedNumbers,
                    validator: inputValidator,
                    errorCondition: ErrorCondition.NegativeValuesNotAllowed,
                    userOption: UserOption.AdditionCalculator
                );

                Console.WriteLine("\nYou will now be redirected back to the initial menu.\n");

                break;
            }
        case (int) UserOption.SubtractionCalculator:
            {
                ConsoleOutput.PrintStringCalculatorEntryPrompt(UserOption.SubtractionCalculator);
                var collectedNumbers = ConsoleOutput.ProvideUserInputSection(inputParser, ExtractionMethod.Alphanumeric);

                inputValidator = new OperationValidator(
                    parsedInputCollection: collectedNumbers,
                    failureCondition: num => num > 1000
                );

                ConsoleOutput.HandleOperation(
                    parsedNumbers: collectedNumbers,
                    validator: inputValidator,
                    errorCondition: ErrorCondition.NumbersExceedingLimit,
                    userOption: UserOption.SubtractionCalculator
                );
                
                break;
            }
        case (int) UserOption.Exit: { break; }
        default: { break; }
    }
}
while (!userChoice.Equals((int) UserOption.Exit));