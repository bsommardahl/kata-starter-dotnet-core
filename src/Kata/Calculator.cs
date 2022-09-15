using System;

namespace Kata
{
    public class Calculator
    {
        public int Calculate(string numbersToSum)
        {
            if (numbersToSum.Contains(','))
            {
                var nums = numbersToSum.Split(',');
                return Convert.ToInt32(nums[0]) + Convert.ToInt32(nums[1]);
            }
            return numbersToSum == "" ? 0 : Convert.ToInt32(numbersToSum);
        }
    }
}