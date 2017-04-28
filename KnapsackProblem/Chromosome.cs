using System;
using System.Collections.Generic;
using System.Text;

namespace KnapsackProblem
{
    internal abstract class Chromosome
    {
        protected Dictionary<int, KeyValuePair<double, double>> Items;
        protected Random Random { get; }
        public Gene[] Genes { get; }

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

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (var i = 0; i < Genes.Length; i++)
            {
                sb.Append(Convert.ToInt32(Genes[i].On));
            }
            sb.Append(" [" + TotalWeight + " | " + TotalValue + " ]");
            return sb.ToString();
        }
    }
}
