using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnapsackProblem
{

    abstract class Gene
    {
        public bool On { get; set; }
        protected Random _random;

        public Gene(Random random)
        {
            _random = random;
        }

    }
}
