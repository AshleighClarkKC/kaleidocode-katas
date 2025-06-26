using Microsoft.Extensions.Configuration;
using static Kaleidocode.Katas.Tests.Constants.ConfigurationConstants;

namespace Kaleidocode.Katas.Tests.Contracts;

public interface IFixture
{
    IConfiguration GetConfiguration(string filePath, bool optional = false)
        => new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(filePath, optional)
            .Build();

    int GetMaxValue()
        => int.Parse(
            GetConfiguration(CONFIGURATION_FILE_NAME)[ADDITION_MAX_VALUE_KEY]!
            );

    void SetTestCondition(Func<int, bool> condition);

    void SetInputValue(string inputValue);

    IEnumerable<int> GetCollectedValues();

    bool Validate();
}
