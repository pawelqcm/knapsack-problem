using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnapsackProblem
{
    class RandomGene : Gene
    {
        public RandomGene(Random random) : base(random)
        {
            On = (_random.NextDouble() < .25) ? true : false;
        }
    }
}
