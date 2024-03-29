using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;


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
            input = ProcessCustomDelimiter(input);

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
                if (Int32.Parse(numbers[i]) <= 1000)
                    sum = sum + Int32.Parse(numbers[i]);
            }

            if (negatives.Count > 0)
            {
                string negAll = string.Join(",", negatives.ToArray());
                throw new System.Exception("The input contains at least one negative number: " + negAll);
            }

            return sum;
        }

        //find and replace custom delimiter with comma delimter  
        private static string ProcessCustomDelimiter(string input)
        {
            //check if there is multiple custom delimiters with any length charaters
            if (input.Contains("]["))
            { 
                int length = input.IndexOf("\n") - 2;
                string delimiterSection = input.Substring(2, length);
                //remove leading delimiter section 
                input = input.Replace("//" + delimiterSection + "\\n", "").Replace("//" + delimiterSection + "\n", "");

                //remove leading "[" and traling "]"
                delimiterSection = delimiterSection.Substring(1, delimiterSection.Length - 1);
                delimiterSection = delimiterSection.Replace("]", "");
                string[] delimiters = delimiterSection.Split('[');
   
                //replace custom delimiter with comma delimters
                foreach (string delimiter in delimiters)
                {
                    input = input.Replace(delimiter, ",");
                }
                   
                return input;
            }
            
            else
                return ProcessAnyLengthSingleDelimiter(input);
        }

        private static string ProcessAnyLengthSingleDelimiter(string input)
        {
            //check if there is any custom delimiter with any length charaters
            if (input.StartsWith("//[") && (input.Contains("]\n") || input.Contains("]\\n")))
            {
                int length = input.IndexOf("]\n") - 3;
                string customDelimiter = input.Substring(3, length);
                //remove leading delimiter section 
                input = input.Replace("//[" + customDelimiter.ToString() + "]\\n", "").Replace("//[" + customDelimiter.ToString() + "]\n", "");
                //replace custom delimiter with comma delimter
                input = input.Replace(customDelimiter, ",");
                return input;
            }
            else
                return ProcessSingleCharDelimiter(input);
        }

        private static string ProcessSingleCharDelimiter(string input)
        {
            //check if there is any custom single character length delimiter
            if (input.StartsWith("//") && (input.Contains("\n") || input.Contains("\\n")))
            {
                char customDelimiter = input[2];
                //remove leading delimiter section 
                input = input.Replace("//" + customDelimiter.ToString() + "\\n", "").Replace("//" + customDelimiter.ToString() + "\n", "");
                //replace custom delimiter with comma delimter
                input = input.Replace(customDelimiter, ',');
                return input;
            }
            else
                return input;

        }
    }
}
