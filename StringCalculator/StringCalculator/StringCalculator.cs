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

            // Case single number
            bool isNumber = Int32.TryParse(numbers, out int number);
            if (isNumber)
                return number;

            // Case multiple number
            var delimiters = new[] { '\n', ',' };
            var nums = numbers.Split(delimiters);
            int num = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                bool isNum = Int32.TryParse(nums[i], out int convertedNum);

                if (!isNum)
                {
                    num = 0;
                    break;
                }

                num = num + convertedNum;
            }

            return num;
        }
    }
}
