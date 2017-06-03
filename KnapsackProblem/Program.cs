using System;

namespace KnapsackProblem
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // sample random input
            // var input = new RandomInput(50);

            // sample file input
            var input = new FileInput();
            try
            {
                input.Fill("input.txt");
            }
            catch
            {
                Console.WriteLine("File input error. Program aborted ");
                return;
            }

            // sample knapsack
            var knapsack = new Knapsack(10, input.Items, 100, new ConsoleLogger()); // change to FileLogger to save to file
                knapsack.Solve(100000);

        }
    }
}
