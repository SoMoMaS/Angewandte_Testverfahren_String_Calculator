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

            List<string> delimiters = new List<string>() { "\n", "," };

            // Case custom single delimiter
            bool isCustom = numbers.Contains("//");
            if (isCustom && !numbers.Contains('[') && !numbers.Contains(']'))
            {
                var lines = numbers.Split('\n');
                int lastIndex = lines[0].LastIndexOf("/");
                delimiters.Add(lines[0][lastIndex + 1].ToString());
                numbers = numbers.Remove(0, 4);
            }

            // Case custom long delimiter
            if (isCustom && numbers.Contains('[') && numbers.Contains(']'))
            {
                //var lines = numbers.Split('\n');
                //var delimiterWS = lines[0].Split('[');
                //var delimiter = delimiterWS[1].Split(']');

                var lines = numbers.Split('\n');
                var dels = lines[0].Remove(0, 2);
                var delimeters = dels.Split(new[] { '[', ']' });
                List<string> mixed = new List<string>(delimeters);
                var clean = mixed.FindAll(s => s != string.Empty);
                clean.ForEach(s => delimiters.Add(s));

                numbers = lines[1];
            }

            // Case single number
            bool isNumber = Int32.TryParse(numbers, out int number);
            if (isNumber)
            {
                if (number > 1000)
                {
                    return 0;
                }
                else
                    return number;
            }

            // Case multiple number
            var nums = numbers.Split(delimiters.ToArray(), StringSplitOptions.None);
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

                if (convertedNum > 1000)
                    convertedNum = 0;

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
