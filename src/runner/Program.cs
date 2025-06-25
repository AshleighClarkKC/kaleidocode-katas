using Kaleidocode.Katas.Runner.Constants;
using Kaleidocode.Katas.Runner.Enumerations;
using Kaleidocode.Katas.Runner.Utilities;
using Kaleidocode.Katas.Libraries.StringCalculator.Parsers;
using Kaleidocode.Katas.Libraries.StringCalculator.Validators;
using Kaleidocode.Katas.Libraries.Contracts;
using Kaleidocode.Katas.Libraries.StringCalculator.Enumerations;

using Microsoft.Extensions.Configuration;
using Kaleidocode.Katas.Libraries.IO.Readers;
using Kaleidocode.Katas.Libraries.StringReader.Parsers;

int userChoice;
IValidator inputValidator;
INumericParser inputParser;
IFileReader fileReader;
IStringParser stringParser;

IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile(ConfigurationConstants.CONFIGURATION_FILE_NAME, false)
    .Build();

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
                var collectedNumbers = ConsoleOutput.GetUserInputForNumericConversion(inputParser, ExtractionMethod.StrictNumeric);

                inputValidator = new OperationValidator(
                    parsedInputCollection: collectedNumbers,
                    failureCondition: num => int.IsNegative(num)
                );

                ConsoleOutput.HandleOperation(
                    parsedNumbers: collectedNumbers,
                    validator: inputValidator,
                    errorCondition: ErrorCondition.NegativeValuesNotAllowed,
                    userOption: UserOption.AdditionCalculator,
                    configuration: configuration
                );

                break;
            }
        case (int) UserOption.SubtractionCalculator:
            {
                ConsoleOutput.PrintStringCalculatorEntryPrompt(UserOption.SubtractionCalculator);
                var collectedNumbers = ConsoleOutput.GetUserInputForNumericConversion(inputParser, ExtractionMethod.Alphanumeric);

                inputValidator = new OperationValidator(
                    parsedInputCollection: collectedNumbers,
                    failureCondition: num => num > 1000
                );

                ConsoleOutput.HandleOperation(
                    parsedNumbers: collectedNumbers,
                    validator: inputValidator,
                    errorCondition: ErrorCondition.NumbersExceedingLimit,
                    userOption: UserOption.SubtractionCalculator,
                    configuration: configuration
                );

                break;
            }
        case (int)UserOption.FileReader:
            {
                ConsoleOutput.PrintReaderOperationExplanation();
                fileReader = new FileReader($"{Directory.GetCurrentDirectory()}\\Data\\data.txt");
                stringParser = new LineParser();

                var testData = fileReader.ReadFile();
                stringParser.SetInputCollection(testData);
                
                ConsoleOutput.PrintCollectionData(testData);
                var collectedValues = stringParser.CollectValues();

                ConsoleOutput.PrintCollectionData(collectedValues.ToArray());

                break;
            }
        case (int) UserOption.Exit: { break; }
        default: { break; }
    }

    Console.WriteLine("\nYou will now be redirected back to the initial menu.\n");
}
while (!userChoice.Equals((int) UserOption.Exit));