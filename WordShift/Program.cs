using System;
using System.Text;

namespace WordShift
{
    class Program
    {
        static void Main(string[] args)
        {
            var word = string.Empty;
            while (string.IsNullOrEmpty(word))
            {
                Console.Write("Please Enter Word To Shift: ");
                word = Console.ReadLine();
            }
            string num = string.Empty;

            //because when the last time you actually used a do-while  :)
            do
            {
                StringBuilder st = new StringBuilder();
                st.Append("Number of Characters To Shift To The Right ");
                if (word.Length == 0)
                    st.Append("(Length of 1)");
                else
                    st.Append("(From 0 to " + (word.Length == 1 ? 1 : (word.Length - 1)) + ")");
                st.Append(": ");
                Console.Write(st.ToString());
                num = Console.ReadLine();

            } while (!ValidateNumber(word, num));

            Console.WriteLine("The Word Shifted By " + num + " to the Right is : " + ShiftString(word, int.Parse(num)));

            Console.WriteLine("Press ENTER to Close Application");
            Console.Read();
        }

        private static bool ValidateNumber(string word, string num)
        {
            int n;
            if (!int.TryParse(num, out n))
                return false;
            else if (string.IsNullOrEmpty(word))
                return false;
            //Doing 0 or Length returns same result as input
            //Lots of validation here; handling case of 1 character put in
            //in addition to standard range checking
            else if (n < 0 || (n > (word.Length - 1) && !(word.Length == 1 && n == 1)))
                return false;

            return true;
        }

        public static string ShiftString(string t, int n)
        {
            return t.Substring(t.Length - n) + t.Substring(0, (t.Length - n));
        }
    }
}
