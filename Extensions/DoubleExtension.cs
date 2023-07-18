using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions_Lecture9.Extensions
{
    public static class DoubleExtension
    {
        public static double ToPercent(this double number)
        {
            return number * 100;
        }
        public static double RoundDown(this double number)
        {
            return (int)number;
        }
        public static decimal ToDecimal(this double number)
        {
            return (decimal)number;
        }
        public static bool IsGreater(this double number, double compareValue)
        {
            return number > compareValue;
        }
        public static bool IsLess(this double number, double compareValue)
        {
            return number < compareValue;
        }

    }
}
