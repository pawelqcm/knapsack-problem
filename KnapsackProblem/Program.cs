namespace KnapsackProblem
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // sample random input
            var input = new RandomInput(50);

            // sample knapsack
            var knapsack = new Knapsack(input.Items.Count, input.Items, 100, new ConsoleLogger()); // change to FileLogger to save to file
            knapsack.Solve(100000);
        }
    }
}
