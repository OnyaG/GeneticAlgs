using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgs
{
    public class GeneticAlg: GeneticAlgBase
    {
        public GeneticAlg(int n, FitnessFunc fitness) : base(n, fitness)
        {

        }

        public override Individual GetResult()
        {
            return new Individual(14);
        }
    }
}
