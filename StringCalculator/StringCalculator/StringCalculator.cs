using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleTo("StringCalculator_NUnitTests")]

namespace StringCalculator
{
    public static class StringCalculator
    {
        internal static int Add(string numbers)
        {
            if (string.IsNullOrWhiteSpace(numbers))
                return 0;

            List<char> delimiters = new List<char>() { '\n', ',' };

            // Case custom
            bool isCustom = numbers.Contains("//");
            if (isCustom)
            {
                var lines = numbers.Split('\n');
                int lastIndex = lines[0].LastIndexOf("/");
                delimiters.Add(lines[0][lastIndex + 1]);
                numbers = numbers.Remove(0, 4);
            }

            // Case single number
            bool isNumber = Int32.TryParse(numbers, out int number);
            if (isNumber)
                return number;

            // Case multiple number
            var nums = numbers.Split(delimiters.ToArray());
            int num = 0;

            List<int> negativNums = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                bool isNum = Int32.TryParse(nums[i], out int convertedNum);

                if (!isNum)
                {
                    num = 0;
                    break;
                }

                // Negative case
                if (convertedNum < 0)
                    negativNums.Add(convertedNum);

                num = num + convertedNum;
            }

            if (negativNums.Count > 0)
            {
                string stringNums = string.Empty;
                negativNums.ForEach(s => stringNums = stringNums + " " + s.ToString());
                throw new InvalidOperationException($"Negatives not allowed: {stringNums}");
            }
                

            return num;
        }
    }
}
