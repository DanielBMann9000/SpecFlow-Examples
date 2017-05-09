using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    public static class Calculator
    {
        public static int Add(IEnumerable<int> numbers)
        {
            return numbers.Sum();
        }

        public static int Subtract(IEnumerable<int> numbers)
        {
            int acc = 0;
            numbers.Select(s => acc - s).ToList();
            return acc;
        }
    }
}
