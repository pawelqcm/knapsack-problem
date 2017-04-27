using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnapsackProblem
{
    class Population
    {
        private static int GenerationNo = 0;
        private readonly double _mutationChance = .5;

        private List<Chromosome> _chromosomes;
        private Dictionary<int, KeyValuePair<double, double>> _items { get; }
        private int _solutions;
        private int _capacity;
        private Random _random;

        public int Generation
        {
            get
            {
                return GenerationNo;
            }
        }

        public int Length {
            get
            {
                return _items.Count;
            }
        }

        public Population(Dictionary<int, KeyValuePair<double, double>> items, int capacity, int solutions, Random random)
        {
            _items = items;
            _capacity = capacity;
            _solutions = solutions;
            _random = random;

            _chromosomes = new List<Chromosome>();
            for (var i = 0; i < _solutions; i++)
            {
                _chromosomes.Add(new RandomChromosome(_items, _random));
            }
            GenerationNo++;
        }

        public Population(Dictionary<int, KeyValuePair<double, double>> items, int capacity, int solutions, Random random, List<Chromosome> MutatedChromosomes)
        {
            _items = items;
            _capacity = capacity;
            _solutions = solutions;
            _random = random;

            _chromosomes = MutatedChromosomes;
            GenerationNo++;
        }

        public Chromosome GetBest()
        {
            List<Chromosome> Valid = FindValid();
            Chromosome Best = Valid.FirstOrDefault();
            if (Best != null)
            {
                for (var i = 1; i < Valid.Count; i++)
                {
                    if (Valid[i].TotalWeight < _capacity && Valid[i].TotalValue > Best.TotalValue)
                    {
                        Best = Valid[i];
                    }
                }
            }
            return Best;
        }

        private List<Chromosome> FindValid()
        {
            List<Chromosome> Valid = new List<Chromosome>();
            foreach (var c in _chromosomes)
            {
                if (c.TotalWeight <= _capacity)
                {
                    Valid.Add(c);
                }
            }
            return Valid;
        }

        public Population SpawnPopulation()
        {
            List<Chromosome> Valid = FindValid();
            List<Chromosome> Chromosomes = new List<Chromosome>();

            for (var i = 0; i < Valid.Count; i++)
            {
                var m = Valid[i];
                if (Valid.Any())
                {
                    var f = Valid.First();
                    Chromosomes.Add(Cross(m, f));
                    Valid.Remove(m);
                    Valid.Remove(f);
                } else
                {
                    Chromosomes.Add(m);
                }
            }

            while (Chromosomes.Count < _solutions)
                Chromosomes.Add(new RandomChromosome(_items, _random));

            if (_random.NextDouble() < _mutationChance)
            {
                var r = _random.Next(0, Chromosomes.Count);
                Chromosomes[r] = Mutate(Chromosomes[r]);
            }

            Population Spawned = new Population(_items, _capacity, _solutions, _random, Chromosomes);

            return Spawned;
        }

        private Chromosome Mutate(Chromosome chromosome)
        {
            var geneIndex = _random.Next(0, Length);
            chromosome.Genes[geneIndex].On = !chromosome.Genes[geneIndex].On;

            return chromosome;
        }

        private Chromosome Cross(Chromosome mother, Chromosome father)
        {
            int middle = (int)Math.Floor((double)Length / 2);
            Chromosome child = new EmptyChromosome(_items, _random);

            for (var i = 0; i < middle; i++)
            {
                child.Genes[i] = mother.Genes[i];
            }
            for (var i = middle; i < Length; i++)
            {
                child.Genes[i] = father.Genes[i];
            }

            return child;
        }

        public void PrintPopulation()
        {
            foreach (var c in _chromosomes)
            {
                c.PrintChromosome();
            }
            Console.WriteLine();
        }

    }
}
