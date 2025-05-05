using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaleidocode.Katas.Libraries.StringCalculator.Helpers
{
    public class ArithmeticHelper(int? maxIntValue = 1000)
    {
        private int? MaxValue { get; init; } = maxIntValue;

        public int Add(IEnumerable<int> values) 
            // Values over the maxVal are to be ignored by rule of Kata 1.
            => (values.Where(w => w < MaxValue))
                .Sum();

        public static int Subtract(IEnumerable<int> values) 
        {
            int subtractedValue = 0;

            foreach (int val in values) { subtractedValue -= val; }

            return subtractedValue;
        }
    }
}
