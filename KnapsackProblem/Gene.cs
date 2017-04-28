using System;

namespace KnapsackProblem
{
    internal abstract class Gene
    {
        public bool On { get; set; }
        protected Random Random;

        protected Gene(Random random)
        {
            Random = random;
        }

    }
}
