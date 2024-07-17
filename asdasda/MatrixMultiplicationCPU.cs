using System;
using System.Threading.Tasks;

class MatrixGenerationCPU
{
    public static void Main()
    {
        int size = 1000;
        double[] array = GenerateArrayParallel(size * size);

        Console.WriteLine("Array generated using CPU parallel processing.");

        // Uncomment to print the array (it will be very large)
        // PrintArray(array, size);
    }

    public static double[] GenerateArrayParallel(int length)
    {
        double[] array = new double[length];
        Random rand = new Random();

        Parallel.For(0, length, i =>
        {
            lock (rand) // Ensure thread-safe access to the random generator
            {
                array[i] = rand.NextDouble() * 10;
            }
        });

        return array;
    }

    public static void PrintArray(double[] array, int size)
    {
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Console.Write(array[i * size + j] + "\t");
            }
            Console.WriteLine();
        }
    }
}
