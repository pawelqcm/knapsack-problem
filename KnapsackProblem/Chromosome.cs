using System;
using System.Collections.Generic;

namespace KnapsackProblem
{
    internal abstract class Chromosome
    {
        public Gene[] Genes { get; }
        protected Dictionary<int, KeyValuePair<double, double>> Items;
        protected Random Random { get; }

        protected Chromosome(Dictionary<int, KeyValuePair<double, double>> items, Random random)
        {
            Genes = new Gene[items.Count];
            Items = items;
            Random = random;
        }

        public double TotalWeight
        {
            get
            {
                double total = 0;
                for (var i = 0; i < Genes.Length; i++)
                {
                    if (Genes[i].On)
                    {
                        total += Items[i].Key;
                    }
                }
                return total;
            }
        }

        public double TotalValue
        {
            get
            {
                double total = 0;
                for (var i = 0; i < Genes.Length; i++)
                {
                    if (Genes[i].On)
                    {
                        total += Items[i].Value;
                    }
                }
                return total;
            }
        }

        public void PrintChromosome()
        {
            for (var i = 0; i < Genes.Length; i++)
            {
                Console.Write(Convert.ToInt32(Genes[i].On));
            }
            Console.Write(" [{0}, {1}]\n", TotalWeight, TotalValue);
        }

    }
}
