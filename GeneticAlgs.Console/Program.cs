using GeneticAlgs;

public class Programm
{
    public static void Main()
    {
        FitnessFunc fitnessFunc = new FitnessFunc();
        bool[] cromosome = { true, false, true, false, true, true, true, true, true, true, true, true, true, true };
        double[] fitness = fitnessFunc.CountFitnessFunc(cromosome);

        string crStr = "";
        for (int i = 0; i < cromosome.Length; i++)
        {
            crStr += cromosome[i] ? 1 : 0;
        }
        Console.WriteLine(crStr);
        Console.WriteLine(fitness[0]+" C");
        Console.WriteLine(fitness[1]+" R");
        Console.WriteLine(fitness[2]+" fitness");
        Console.ReadLine();
    }
}