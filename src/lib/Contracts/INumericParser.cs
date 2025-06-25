using Kaleidocode.Katas.Libraries.StringCalculator.Enumerations;

namespace Kaleidocode.Katas.Libraries.Contracts;

public interface INumericParser
{
    void SetInputValue(string input);

    IEnumerable<int> CollectValues(ExtractionMethod extractionMethod);
}