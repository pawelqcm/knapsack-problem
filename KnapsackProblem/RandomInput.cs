using System;
using System.Collections.Generic;

namespace KnapsackProblem
{
    internal class RandomInput : Input
    {
        private readonly Random _random;

        public RandomInput(int numberOfItems)
        {
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
