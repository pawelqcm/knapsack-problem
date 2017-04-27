using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnapsackProblem
{
    class Knapsack
    {
        private Dictionary<int, KeyValuePair<double, double>> _items; // given items
        private int _capacity; // max weight
        private int _solutions; // default number of solutions 
        private Population _population; // newest generation
        private Chromosome _best; // best so far
        private Random _random;

        public Knapsack(int capacity, Dictionary<int, KeyValuePair<double, double>> items, int solutions)
        {
            _items = items;
            _capacity = capacity;
            _solutions = solutions;
            _best = new EmptyChromosome(items, _random);
            _random = new Random();
        }

        public void Solve(int Generations)
        {
            _population = new Population(_items, _capacity, _solutions, _random);
            _population.PrintPopulation();

            Console.WriteLine("Looking for solutions..");

            Step(ref Generations);
            while (true)
            {
                if (Generations > 0)
                {
                    _population = _population.SpawnPopulation();
                    Step(ref Generations);
                } else
                    return;
            }
        }

        private void Step(ref int Generation)
        {
            Generation--;
            Update(_population.GetBest());
        }

        private void Update(Chromosome candidate)
        {
            if (candidate != null && candidate.TotalValue > _best.TotalValue)
            {
                _best = candidate;
                Console.Write("new best => ");
                _best.PrintChromosome();
            }
        }

    }
}
