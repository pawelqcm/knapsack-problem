using System.Collections.Generic;

namespace KnapsackProblem
{
    internal abstract class Input
    {
        public Dictionary<int, KeyValuePair<double, double>> Items { get; protected set; }
        public double WeightTotal { get; protected set; }
        public double ValueTotal { get; protected set; }

        protected Input()
        {
            Items = new Dictionary<int, KeyValuePair<double, double>>();
        }
    }
}
