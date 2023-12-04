using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace GeneticAlgs
{
    public struct IndividualFitness
    {
        private double fitnessFunc;
        private double individualCost;
        private double individualRisk;
        public double FitnessFunc { get { return fitnessFunc; } }
        public double IC { get { return individualCost; } }
        public double IR { get { return individualRisk; } }

        public IndividualFitness(double fitness, double cost, double risk)
        {
            fitnessFunc = fitness;
            individualCost = cost;
            individualRisk = risk;
        }
    }
    public class Individual
    {
        private bool[] _cromosome;
        private int _length;
        private IndividualFitness? _individualFitness;
        public bool[] Cromosome { get { return _cromosome; } }
        public int Length { get { return _length; } }
        public IndividualFitness? GetIndividualFitness
        {
            get { return _individualFitness; }
        }

        public Individual(int length)
        {
            _cromosome = GenerateIndividual();
            _length = length;
        }
        public Individual(bool[] cromosome)
        {
            _cromosome = cromosome;
        }

        private bool[] GenerateIndividual()
        {
            bool[] cromosome = new bool[_length];
            for(int i = 0; i < _length; i++) 
            {
                cromosome[i] = RandomBool.GetRandomBool();
            }
            return cromosome;
        }

        public void DoFitnessFunc(FitnessFunc fitnessFunc)
        {
            _individualFitness = fitnessFunc.CountFitnessFunc(_cromosome);
        }
    }
}
