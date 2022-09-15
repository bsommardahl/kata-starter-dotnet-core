using System;

namespace Kata
{
    public class Calculator
    {
        public int Calculate(string numbersToSum)
        {
            return numbersToSum == "" ? 0 : Convert.ToInt32(numbersToSum);
        }
    }
}