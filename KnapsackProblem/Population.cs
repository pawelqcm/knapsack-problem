using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KnapsackProblem
{
    internal class Population
    {
        private static int _generationNo;
        private const double MutationChance = .5;

        private readonly List<Chromosome> _chromosomes;
        private readonly int _solutions;
        private readonly int _capacity;
        private readonly Random _random;
        private Dictionary<int, KeyValuePair<double, double>> Items { get; }

        public int Generation => _generationNo;
        public int Length => Items.Count;

        public Population(Dictionary<int, KeyValuePair<double, double>> items, int capacity, int solutions, Random random)
        {
            Items = items;
            _capacity = capacity;
            _solutions = solutions;
            _random = random;

            _chromosomes = new List<Chromosome>();
            for (var i = 0; i < _solutions; i++)
            {
                _chromosomes.Add(new RandomChromosome(Items, _random));
            }
            _generationNo++;
        }

        public Population(Dictionary<int, KeyValuePair<double, double>> items, int capacity, int solutions, Random random, List<Chromosome> mutatedChromosomes)
        {
            Items = items;
            _capacity = capacity;
            _solutions = solutions;
            _random = random;

            _chromosomes = mutatedChromosomes;
            _generationNo++;
        }

        public Chromosome GetBest()
        {
            var valid = FindValid();
            var best = valid.FirstOrDefault();
            if (best != null)
            {
                for (var i = 1; i < valid.Count; i++)
                {
                    if (valid[i].TotalWeight < _capacity && valid[i].TotalValue > best.TotalValue)
                    {
                        best = valid[i];
                    }
                }
            }
            return best;
        }

        private List<Chromosome> FindValid()
        {
            return _chromosomes.Where(c => c.TotalWeight <= _capacity).ToList();
        }

        public Population SpawnPopulation()
        {
            var valid = FindValid();
            var chromosomes = new List<Chromosome>();

            for (var i = 0; i < valid.Count; i++)
            {
                var m = valid[i];
                if (valid.Any())
                {
                    var f = valid.First();
                    chromosomes.Add(Cross(m, f));
                    valid.Remove(m);
                    valid.Remove(f);
                } else
                {
                    chromosomes.Add(m);
                }
            }

            while (chromosomes.Count < _solutions)
                chromosomes.Add(new RandomChromosome(Items, _random));

            if (_random.NextDouble() < MutationChance)
            {
                var r = _random.Next(0, chromosomes.Count);
                chromosomes[r] = Mutate(chromosomes[r]);
            }

            var spawned = new Population(Items, _capacity, _solutions, _random, chromosomes);

            return spawned;
        }

        private Chromosome Mutate(Chromosome chromosome)
        {
            var geneIndex = _random.Next(0, Length);
            chromosome.Genes[geneIndex].On = !chromosome.Genes[geneIndex].On;

            return chromosome;
        }

        private Chromosome Cross(Chromosome mother, Chromosome father)
        {
            var middle = (int)Math.Floor((double)Length / 2);
            Chromosome child = new EmptyChromosome(Items, _random);

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

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var c in _chromosomes)
            {
                sb.AppendLine(c.ToString());
            }
            return sb.ToString();
        }

    }
}
