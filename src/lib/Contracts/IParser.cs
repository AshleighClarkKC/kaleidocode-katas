using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kaleidocode.Katas.Libraries.StringCalculator.Enumerations;

namespace Kaleidocode.Katas.Libraries.Contracts
{
    public interface IParser
    {
        void SetInputValue(string input);

        IEnumerable<int> CollectNumbers(ExtractionMethod extractionMethod);
    }
}
