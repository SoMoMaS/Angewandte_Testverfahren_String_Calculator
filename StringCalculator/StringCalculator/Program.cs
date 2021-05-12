using System;
using System.Collections.Generic;

namespace StringCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var asd = new List<int>() { -1, -2, -3 };
            string nums = string.Empty;
            asd.ForEach(s => nums = nums + " " + s.ToString());
            Console.WriteLine($"Negatives are not allowed: {nums}");
        }
    }
}
