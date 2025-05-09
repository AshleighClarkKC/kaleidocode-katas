using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaleidocode.Katas.Tests.Contracts
{
    public interface IFixture
    {
        void SetTestCondition(Func<int, bool> condition);

        void SetInputValue(string inputValue);

        IEnumerable<int> GetCollectedValues();

        bool Validate();
    }
}
