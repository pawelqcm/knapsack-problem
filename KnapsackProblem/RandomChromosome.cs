using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnapsackProblem
{
    class RandomChromosome : Chromosome
    {
        public RandomChromosome(Dictionary<int, KeyValuePair<double, double>> items, Random random) : base(items, random)
        {
            for (var i = 0; i < items.Count; i++)
            {
                Genes[i] = new RandomGene(_random);
            }
        }
    }
}
