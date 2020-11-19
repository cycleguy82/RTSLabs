using System;
using System.Collections.Generic;
using System.Linq;

namespace ArrayCompare
{
    class Program
    {
        static void Main(string[] args)
        {
            string nums = string.Empty;
            do
            {
                Console.Write("Enter a Comma Delimited List of Numbers: ");
                nums = Console.ReadLine();
            } while (!(nums.Any(char.IsDigit) && nums.Contains(",") && !string.IsNullOrEmpty(nums)));


            int NumberToCompare;
            do
            {
                Console.Write("Enter a Number To Compare: ");
            }
            while (!int.TryParse(Console.ReadLine(), out NumberToCompare));

            List<int> convertedNums = new List<int>();
            nums.Split(',').ToList().ForEach(delegate (string st) { int convertedInt = 0; if (int.TryParse(st, out convertedInt)) convertedNums.Add(convertedInt); });

            int aboveTotal = 0;
            int belowTotal = 0;
            int equalTotal = 0;

            ComputeTotals(convertedNums, NumberToCompare, out aboveTotal, out equalTotal, out belowTotal);

            Console.WriteLine("Total Above: " + aboveTotal);
            Console.WriteLine("Total Below: " + belowTotal);
            Console.WriteLine("Total Equal: " + equalTotal);

            Console.Write("Press ENTER to Close Application.");
            Console.Read();
        }


        //Could of done a Tuple as a result set; but tried to keep it simple so used Outs.
        public static void ComputeTotals(List<int> list, int Number, out int aboveCount, out int equalCount, out int belowCount)
        {
            aboveCount = belowCount = equalCount = 0;

            belowCount = list.Where(p => p < Number).Count();
            aboveCount = list.Where(p => p > Number).Count();
            equalCount = list.Where(p => p == Number).Count();
        }
    }
}
