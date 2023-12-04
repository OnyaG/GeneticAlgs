using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgs
{
    /*Компактный ГА
{
Инициализация вектора вероятностей P ;
// присваивание  0,5 i p для всех 1 i  N
// основной цикл алгоритма
while (критерий_останова <> TRUE)
{
// генерация двух особей виртуальной популяции мощности M
a = сгенерировать ( P );
b = сгенерировать ( P );
// определение победителя и проигравшего
if (фитнесс ( a ) > фитнесс (b ))
    then победитель = a
else победитель = b
// изменение вектора вероятности P
while ( i  N )
{
if (победитель [ i ]  проигравший [ i ]) then
if (победитель [ i ] = 1) then
M
p pi i
1
  else
M
p pi i
1
 
}
}
return P .
}*/
    public class CompactGeneticAlg : GeneticAlgBase
    {
        private List<double> probability = new List<double>();
        private int numberOfTours = 50;
        public CompactGeneticAlg(int n, FitnessFunc fitness) : base(n, fitness)
        {
            
        }

        public override Individual GetResult()
        {
            InitVector();
            double addingProbability = (1.0 / N);
            Individual a, b;
            for (int i = 0; i < numberOfTours; i++) //количество туров
            {
                InitProbabilityPopulation();
                for (int j = 0; j < N / 2; j++) //количество турниров в туре
                {
                    a = _individuals[j*2];
                    b = _individuals[j*2+1];
                    a.DoFitnessFunc(_fitnessFunc);
                    b.DoFitnessFunc(_fitnessFunc);
                    
                    if (a.GetIndividualFitness?.FitnessFunc < b.GetIndividualFitness?.FitnessFunc)
                    {
                        for(int k =0; k < a.Cromosome.Length; k++)
                        {
                            if (a.Cromosome[k] == b.Cromosome[k]) continue;
                            probability[k] += addingProbability * (a.Cromosome[k] ? 1 : -1);
                            if (probability[k] < 0) probability[k] = 0;
                            if (probability[k] > 1) probability[k] = 1;
                        }
                    }
                    else
                    {
                        for (int k = 0; k < b.Cromosome.Length; k++)
                        {
                            if (a.Cromosome[k] == b.Cromosome[k]) continue;
                            probability[k] += addingProbability * (b.Cromosome[k] ? 1 : -1);
                            if (probability[k] < 0) probability[k] = 0;
                            if (probability[k] > 1) probability[k] = 1;
                        }
                    }
                }
            }
            Individual bestIndividual = GenerateBest();
            return bestIndividual;
        }

        private void InitVector()
        {
            for (int i = 0; i < FitnessFunc.Cost.Count; i++)
            {
                probability.Add(0.5);
            }
        }

        private Individual GenerateBest()
        {
            var length = FitnessFunc.Cost.Count;
            bool[] cromosome = new bool[length];
            for (int i = 0; i < length; i++)
            {
                cromosome[i] = probability[i]<=0.5? true: false;
            }
            return new Individual(cromosome);
        }

        private void InitProbabilityPopulation()
        {
            _individuals.Clear();
            for (int i = 0; i < N; i++)
            {
                _individuals.Add(GenerateIndividualByProbability());
            }
        }

        private Individual GenerateIndividualByProbability()
        {
            var length = FitnessFunc.Cost.Count;
            bool[] cromosome = new bool[length];
            for (int i = 0;i< length; i++)
            {
                cromosome[i] = RandomBoolByProbability.GetRandomBool(probability[i]);
            }
            return new Individual(cromosome);
        }
        
    }
}
