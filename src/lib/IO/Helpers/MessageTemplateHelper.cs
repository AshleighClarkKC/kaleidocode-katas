using Kaleidocode.Katas.Libraries.IO.Enumerations;

namespace Kaleidocode.Katas.Libraries.IO.Helpers;

public static class MessageTemplateHelper
{
    public static string GenerateGenericErrorString(ErrorCondition condition, string paramName)
        => condition switch
        {
            ErrorCondition.ValueRequired => $"A value is required for \"{paramName}\".",
            _ => "The error condition has not been defined as yet."
        };
}