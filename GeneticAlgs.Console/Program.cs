using GeneticAlgs;

public class Programm
{
    public static void Main()
    {
        bool[] cromosome = { true, false, true, false, true, true, true, true, true, true, true, true, true, true };
        double RiskWithoutGuard = 421945.84;
        List<double> V = new List<double>() { 0.98, 0.84, 1, 0.68, 0.98, 1, 0.98, 0.86, 0.84, 0.8, 0.88, 0.84, 1, 0.88 };
        List<double> C = new List<double>() { 2000, 3020000, 105000, 4010000, 2630000, 520000, 4000, 408000, 2508000, 158000, 58000, 1008000, 4000, 4000 };
        List<double> D  = new List<double>() { 43939, 117318, 34707, 32297, 48994, 28349, 64559, 108443, 52560, 50658, 62272, 118839, 71289, 37207 };
        List<double> P  = new List<double>() { 0.73, 0.3, 0.86, 0.77, 0.65, 0.81, 0.53, 0.4, 0.69, 0.77, 0.61, 0.34, 0.49, 0.77 };

        var fitness = new FitnessFunc(RiskWithoutGuard, V, C, D, P);

        var geneticAlg = new CompactGeneticAlg(50, fitness);
        var best = geneticAlg.GetResult();
        best.DoFitnessFunc(fitness);
        string crStr = "";
        cromosome = best.Cromosome;
        var xc = best.GetIndividualFitness?.IC;
        var xr = RiskWithoutGuard- best.GetIndividualFitness?.IR;
        for (int i = 0; i < cromosome.Length; i++)
        {
            crStr += cromosome[i] ? 1 : 0;
        }
        Console.WriteLine(crStr);

        Console.WriteLine(xc + " xc");
        Console.WriteLine(xr + " xr");

        Console.ReadKey();
    }
}