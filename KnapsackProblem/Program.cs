using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnapsackProblem
{

    class Program
    {
        static void Main(string[] args)
        {
            // sample random input
            RandomInput input = new RandomInput(50);

            // sample knapsack
            Knapsack knapsack = new Knapsack(input.Items.Count, input.Items, 100);
            knapsack.Solve(100000);
        }
    }
}
