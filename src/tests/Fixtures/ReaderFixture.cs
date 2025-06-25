using Kaleidocode.Katas.Libraries.Contracts;
using Kaleidocode.Katas.Libraries.IO.Readers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaleidocode.Katas.Tests.Fixtures
{
    public class ReaderFixture
    {
        internal IFileReader GetFileReader()
        {
            return new FileReader($"{Directory.GetCurrentDirectory()}\\Specimen\\test.txt");
        }
    }
}
