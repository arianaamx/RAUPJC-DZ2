using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_8_zadatak
{
    class Program
    {
        static void Main(string[] args)
        {
            // Main method is the only method that
            // can ’t be marked with async .
            // What we are doing here is just a way for us to simulate
            // async - friendly environment you usually have with
            // other .NET application types ( like web apps , win apps etc .)
            // Ignore main method , you can just focus on
            //LetsSayUserClickedAButtonOnGuiMethod() as a
            // first method in call hierarchy .
            var t = Task.Run(() => LetsSayUserClickedAButtonOnGuiMethod());
            Console.Read();
        }

        private static async Task LetsSayUserClickedAButtonOnGuiMethod()
        {
            var result = await GetTheMagicNumber();
            Console.WriteLine(result);
        }

        private static async Task<int> GetTheMagicNumber()
        {
            return await IKnowIGuyWhoKnowsAGuy();
        }

        private static async Task<int> IKnowIGuyWhoKnowsAGuy()
        {
            int n, m;
            n = await IKnowWhoKnowsThis(10);
            m = await IKnowWhoKnowsThis(5);
            return (n + m);
        }
        private static async Task<int> IKnowWhoKnowsThis(int n)
        {
            return await FactorialDigitSum(n);
        }

        public static async Task<int> FactorialDigitSum(int n)
        {
            return await Task.Run(() =>
            {
                int fact = 1;
                while (n > 1)
                {
                    fact *= n--;
                }
                int sum = 0;
                while (fact > 0)
                {
                    sum += fact % 10;
                    fact /= 10;
                }
                return sum;
            });
        }
    }
}
