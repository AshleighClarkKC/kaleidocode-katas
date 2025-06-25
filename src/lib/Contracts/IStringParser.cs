using Kaleidocode.Katas.Libraries.StringCalculator.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaleidocode.Katas.Libraries.Contracts
{
    public interface IStringParser
    {
        void SetInputCollection(string[] valueCollection);

        IEnumerable<string> CollectValues();
    }
}
