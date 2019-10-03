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
            char[] charSeparators = new char[] { ',' };
            string[] numbers = input.Split(charSeparators);

            Int32 sum = 0;

            int count = numbers.Count();

            for (int i = 0; i < count; i++)
            {
                if (!(Int32.TryParse(numbers[i], out int numberValue)))
                    numbers[i] = "0";
                sum = sum + Int32.Parse(numbers[i]);
            }
    
            return sum;
        }
    }
}
