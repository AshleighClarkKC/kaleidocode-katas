
namespace Kaleidocode.Katas.Libraries.Contracts;

public interface IValidator
{
    void SetInputCollection(IEnumerable<int> inputCollection);

    void SetValidationCondition(Func<int, bool> condition);

    bool Validate(Func<string, string> errorMessageTemplate);

    string CollectIncompatibleValues(IEnumerable<int> parsedValues, Func<int, bool> failureCondition);
}