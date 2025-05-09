using System;
using System.Collections.Generic;
using System.Linq;

namespace Kaleidocode.Katas.Libraries.StringCalculator.Helpers
{
    public static class ArithmeticHelper
    {
        public static int Add(IEnumerable<int> values, int? maxValue = 1000) 
            // Values over the maxVal are to be ignored by rule of Kata 1.
            => (values.Where(w => w < maxValue))
                .Sum();

        public static int Subtract(IEnumerable<int> values) 
        {
            int subtractedValue = 0;

            foreach (int val in values) { subtractedValue -= val; }

            return subtractedValue;
        }
    }
}
