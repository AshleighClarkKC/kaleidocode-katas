
namespace Kaleidocode.Katas.Libraries.Contracts;

public interface IValidator
{
    bool Validate();

    string CollectIncompatibleValues(IEnumerable<int> parsedValues, Func<int, bool> failureCondition);
}