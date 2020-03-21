using System;
using System.Linq;

namespace Kata
{
    public class Calculator
    {
        public int Add(string s = "")
        {
            if (string.IsNullOrEmpty(s))
                return 0;

            var separator = new[] {",", "\n"};
            var unparsedNumbers = s;

            if (s.StartsWith("//"))
            {
                var parts = s.Split("\n");

                separator = parts[0].Replace("//", "").Replace("[","").Split("]");
                unparsedNumbers = parts[1];
            }

            var numbers = unparsedNumbers.Split(separator, StringSplitOptions.None).Select(int.Parse).ToList();

            var negatives = numbers.Where(x => x < 0).ToList();
            if (negatives.Any()) throw new Exception("negatives not allowed: " + string.Join(", ", negatives));
            return numbers.Where(x=> x < 1001).Sum();
        }
    }
}