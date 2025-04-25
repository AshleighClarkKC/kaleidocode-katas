using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaleidocode.Katas.Libraries.StringCalculator.Helpers
{
    public class ArithmeticHelper(int? maxIntValue = 1000)
    {
        private int? MaxIntegerValue { get; init; } = maxIntValue;

        /// <summary>
        /// Sums up values in the provided collection.
        /// </summary>
        /// <param name="values">The collection of accepted values.</param>
        /// <returns>Returns the added value of the elements in the provided collection.</returns>
        public int Add(IEnumerable<int> values)
        {
            var sanitizedValues = values.Where(w => w < MaxIntegerValue);

            return sanitizedValues.Sum();
        }
    }
}
