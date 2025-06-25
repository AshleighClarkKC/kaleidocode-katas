using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kaleidocode.Katas.Libraries.StringCalculator.Enumerations;

namespace Kaleidocode.Katas.Libraries.Contracts
{
    public interface INumericParser
    {
        void SetInputValue(string input);

        IEnumerable<int> CollectValues(ExtractionMethod extractionMethod);
    }
}
