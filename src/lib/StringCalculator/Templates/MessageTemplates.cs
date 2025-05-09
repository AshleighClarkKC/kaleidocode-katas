using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kaleidocode.Katas.Libraries.StringCalculator.Enumerations;

namespace Kaleidocode.Katas.Libraries.StringCalculator.Templates
{
    public static class MessageTemplates
    {
        public static string GenerateErrorString(ErrorCondition condition, string incompatibleValues)
            => condition switch 
            {
                ErrorCondition.NegativeValuesNotAllowed => $"Negative numbers not allowed. Incompatible values: \"{incompatibleValues}\".",
                ErrorCondition.NumbersExceedingLimit => $"Numbers exceeding limit. Incompatible values: \"{incompatibleValues}\".",
                _ => throw new ArgumentOutOfRangeException(nameof(condition))
            };
    }
}
