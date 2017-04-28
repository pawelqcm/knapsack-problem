using System;

namespace KnapsackProblem
{
    internal class RandomGene : Gene
    {
        public RandomGene(Random random) : base(random)
        {
            On = (Random.NextDouble() < .25);
        }
    }
}
