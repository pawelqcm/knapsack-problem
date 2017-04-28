using System;
using System.Collections.Generic;

namespace KnapsackProblem
{
    internal class EmptyChromosome : Chromosome
    {
        public EmptyChromosome(Dictionary<int, KeyValuePair<double, double>> items, Random random) : base(items, random)
        {
            for (var i = 0; i < items.Count; i++)
            {
                Genes[i] = new EmptyGene(random);
            }
        }
    }
}
