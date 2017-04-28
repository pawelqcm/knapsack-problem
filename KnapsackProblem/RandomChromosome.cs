using System;
using System.Collections.Generic;

namespace KnapsackProblem
{
   internal  class RandomChromosome : Chromosome
    {
        public RandomChromosome(Dictionary<int, KeyValuePair<double, double>> items, Random random) : base(items, random)
        {
            for (var i = 0; i < items.Count; i++)
            {
                Genes[i] = new RandomGene(random);
            }
        }
    }
}
