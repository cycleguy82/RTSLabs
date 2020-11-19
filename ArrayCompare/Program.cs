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


            int c;
            do
            {
                Console.Write("Ender a Number: ");
            }
            while (!int.TryParse(Console.ReadLine(), out c));

            List<string> splitnums = nums.Split(',').ToList();



            splitnums.ForEach(delegate (string st)
            {
                int n;
                if (int.TryParse(st, out n))
                {
                    if (n == c)
                        Console.WriteLine(n + " is Equal to " + c);
                    else
                        Console.WriteLine(n + " is " + (c.CompareTo(n) == 1 ? "Below " : "Above ") + c);

                }
            });

            Console.Write("Press ENTER to Close Application.");
            Console.Read();
        }
    }
}
