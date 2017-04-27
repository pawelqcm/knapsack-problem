using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnapsackProblem
{
    class RandomInput
    {
        private Random _random;
        public Dictionary<int, KeyValuePair<double, double>> Items { get; }
        public double WeightTotal { get; private set; }
        public double ValueTotal { get; private set; }

        public RandomInput(int numberOfItems)
        {
            Items = new Dictionary<int, KeyValuePair<double, double>>();
            _random = new Random();
            Fill(numberOfItems);
        }

        private void Fill(int numbers)
        {
            for (var i = 0; i < numbers; i++)
            {
                var w = _random.NextDouble() * 10;
                var v = _random.NextDouble() * 10;
                Items.Add(i, new KeyValuePair<double, double>(w, v));
                WeightTotal += w;
                ValueTotal += v;
            }
        }
    }
}
