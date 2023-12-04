using System.Net;
using System.Reflection.Metadata;

namespace GeneticAlgs
{
    public abstract class GeneticAlgBase
    {
        protected List<Individual> _individuals = new List<Individual>();
        public List<Individual> Individuals {  get { return _individuals; } }

        protected int _n;
        protected FitnessFunc _fitnessFunc;
        public int N { get { return _n; } }
        public FitnessFunc FitnessFunc {  get { return _fitnessFunc; } }

        public GeneticAlgBase(int n, FitnessFunc fitnessFunc)
        {
            _n = n;
            _fitnessFunc = fitnessFunc;
        }
        protected void CountFitnessFunc(Individual individual)
        {
            individual.DoFitnessFunc(_fitnessFunc);
        }

        protected void InitPopulation()
        {
            _individuals.Clear();
            var length = FitnessFunc.Cost.Count;
            for (int i= 0; i < N; i++)
            {
                _individuals.Add(new Individual(length));
            }
        }
        public abstract Individual GetResult();
    }

}