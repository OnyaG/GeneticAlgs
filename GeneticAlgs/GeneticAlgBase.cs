namespace GeneticAlgs
{
    public abstract class GeneticAlgBase
    {
        protected List<Individual> _individuals = new List<Individual>();
        public List<Individual> Individuals {  get { return _individuals; } }
        public virtual void CountFitnessFunc(Individual individual)
        {
            individual.DoFitnessFunc();
        }
    }

}