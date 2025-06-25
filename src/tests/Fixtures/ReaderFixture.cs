using Kaleidocode.Katas.Libraries.Contracts;
using Kaleidocode.Katas.Libraries.IO.Readers;

namespace Kaleidocode.Katas.Tests.Fixtures;

public class ReaderFixture
{
    internal IFileReader GetFileReader()
    {
        return new FileReader($"{Directory.GetCurrentDirectory()}\\Specimen\\test.txt");
    }
}
