using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgs
{
    
    public class FitnessFunc
    {
#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
        public FitnessFunc(double risk, List<double> vulnerability, List<double> cost, List<double> damage, List<double> probability)
#pragma warning restore CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
        {
            R0 = risk;
            V = vulnerability;
            C = cost;
            D = damage;
            P = probability;
            SetRisks();
        }

        private double R0;
        private List<double> R;
        private List<double> V;
        private List<double> C;
        private List<double> D;
        private List<double> P;

        public double RiskWithoutGuard{ get { return R0; } }
        public List<double> Risks { get {return R; } }
        public List<double> Vunerability { get { return V; } }
        public List<double> Cost { get { return C; } }
        public List<double> Damage { get {  return D; } }
        public List<double> Probability { get { return P; } }

        public void SetRisks()
        {
            /*
            //Всего в файл загружено
            //14 защитных мер G и их стоимость C,
            //14 оценок уязвимостей V,
            //14 оценок ущерба при реализации угроз D,
            //14 оценок вероятности реализации угрозы P 

            //Величина риска определяется произведением
            //вероятности реализации угрозы на оценку уязвимости
            //и на ущерб в случае осуществления атаки.

            // Величина риска вычисляется как сумма произведений
            // вероятности реализации угрозы p^i
            // на оценку уязвимости v^i
            // и на ущерб в случае осуществления атаки d^i.  
            */

            R = new List<double>();
            for (int i = 0; i < C.Count; i++)
            {
                R.Add(P[i] * V[i] * D[i]);
            }
        }

        public IndividualFitness CountFitnessFunc(bool[] cromosome)
        {
            double fitnessFunc;
            double XC = 0;
            double XR = 0;
            for (int i = 0; i < cromosome.Length; i++)
            {
                XC += cromosome[i] ? C[i] : 0;
                XR += cromosome[i] ? R[i] : 0;
            }
            double globalCost = 8000000;

            fitnessFunc = (RiskWithoutGuard - XR) / XC;
            //if (XC>globalCost)
            //{
            //    double increaser = XC / globalCost;
            //    fitnessFunc = fitnessFunc * increaser;
            //}
            //fitnessFunc = (RiskWithoutGuard - XR) / XC;
            IndividualFitness result = new IndividualFitness(fitnessFunc, XC, XR);
            return result;
        }
    }
}
