using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace caculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to my cool caculator, please enter a string to add:");

            string input = Console.ReadLine();

            var output = Caculater.Add(input);

            Console.WriteLine(output);

            Console.ReadKey();
        }

        
    }

    public static class Caculater
    {
        public static Int32 Add(string input)
        {
            input = input.Replace("\\n", ",").Replace("\n", ",");

            char[] charSeparators = new char[] { ',' };
            string[] numbers = input.Split(charSeparators);

            Int32 sum = 0;
            List<Int32> negatives = new List<Int32>();

            int count = numbers.Count();

            for (int i = 0; i < count; i++)
            {
                if (!(Int32.TryParse(numbers[i], out int numberValue)))
                    numbers[i] = "0";
                if (Int32.Parse(numbers[i]) < 0)
                {
                    negatives.Add(Int32.Parse(numbers[i]));
                }
                sum = sum + Int32.Parse(numbers[i]);
            }

            if (negatives.Count > 0)
            {
                string negAll = string.Join(",", negatives.ToArray());
                throw new System.Exception("The input contains at least one negative number: " + negAll);
            }
    
            return sum;
        }
    }
}
