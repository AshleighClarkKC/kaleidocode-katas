namespace Kaleidocode.Katas.Libraries.StringCalculator.Extensions;

using System.Text;
using System.Text.RegularExpressions;

public static class InputExtensions
{
    public static (int? Value, string? ErrorMessage) SumUserInput(this string? str)
    {
        if (string.IsNullOrEmpty(str))
        {
            return (0, null);
        }

        Regex valueMatchCollection = new ("[\\-\\d]+", RegexOptions.ECMAScript);

        List<int> res = [];
        List<int> incompatibleValues = [];

        foreach (Match match in valueMatchCollection.Matches(str))
        {
            if (match.Success)
            {
                bool parsed = int.TryParse(match.Value, out int parsedValue);

                if (parsed)
                {
                    if (parsedValue >= 0)
                    {
                        if (parsedValue < 1000)
                        {
                            res.Add(parsedValue);
                        }
                    }
                    else
                    {
                        incompatibleValues.Add(parsedValue);
                    }
                }

            }
        }

        StringBuilder collectedValueBuilder = new();

        if (incompatibleValues.Count > 0)
        {
            collectedValueBuilder.Append("Collected Values: ");
            string collectedNumbers = string.Join(',', incompatibleValues);
            collectedValueBuilder.Append(collectedNumbers);

            return (null, collectedValueBuilder.ToString());
        }

        return (res.Sum(), null);

    }

    public static int Sum(this IEnumerable<int> input) 
    {
        int res = 0;

        if (!input.Any())
        {
            return res;
        }

        foreach (int val in input)
        {
            res += val;
        }

        return res;
    }
}
