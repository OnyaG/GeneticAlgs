using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace GeneticAlgs
{
    public class Individual
    {
        private bool[] _cromosome;
        private double? fitnessFunc;
        public bool[] Cromosome { get { return _cromosome; } }

        Individual(int length)
        {
            _cromosome = GenerateIndividual(length);
        }
        Individual(bool[] cromosome)
        {
            _cromosome = cromosome;
        }

        private bool[] GenerateIndividual(int length)
        {
            bool[] cromosome = new bool[length];
            for(int i = 0; i < length; i++) 
            {
                cromosome[i] = RandomBool.GetRandomBool();
            }
            return cromosome;
        }
    }
}
