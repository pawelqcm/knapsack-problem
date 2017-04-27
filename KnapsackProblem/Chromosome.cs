using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnapsackProblem
{

    abstract class Chromosome
    {
        public Gene[] Genes { get; }
        protected Dictionary<int, KeyValuePair<double, double>> _items;
        protected Random _random { get; }
        
        public Chromosome(Dictionary<int, KeyValuePair<double, double>> items, Random random)
        {
            Genes = new Gene[items.Count];
            _items = items;
            _random = random;
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
                        total += _items[i].Key;
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
                        total += _items[i].Value;
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
