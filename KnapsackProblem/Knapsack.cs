using System;
using System.Collections.Generic;

namespace KnapsackProblem
{
    internal class Knapsack
    {
        private readonly Dictionary<int, KeyValuePair<double, double>> _items; // given items
        private readonly int _capacity; // max weight
        private readonly int _solutions; // default number of solutions 
        private Population _population; // newest generation
        private Chromosome _best; // best so far
        private readonly Random _random;

        public Knapsack(int capacity, Dictionary<int, KeyValuePair<double, double>> items, int solutions)
        {
            _items = items;
            _capacity = capacity;
            _solutions = solutions;
            _best = new EmptyChromosome(items, _random);
            _random = new Random();
        }

        public void Solve(int generations)
        {
            _population = new Population(_items, _capacity, _solutions, _random);
            _population.PrintPopulation();

            Console.WriteLine("Looking for solutions..");

            Step(ref generations);
            while (true)
            {
                if (generations > 0)
                {
                    _population = _population.SpawnPopulation();
                    Step(ref generations);
                } else
                    return;
            }
        }

        private void Step(ref int generation)
        {
            generation--;
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
