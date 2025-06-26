namespace Kaleidocode.Katas.Libraries.Contracts;

public interface IStringParser
{
    void SetInputCollection(string[] valueCollection);

    IEnumerable<string> CollectValues();
}

