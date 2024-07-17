using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asdasda
{
    public class MatrixGenerationCPU
    {
        public static float[] GenerateArrayParallel(int length)
        {
            float[] array = new float[length];
            Random rand = new Random();

            Parallel.For(0, length, i =>
            {
                lock (rand) // Ensure thread-safe access to the random generator
                {
                    array[i] = (float)(rand.NextDouble() * 10);
                }
            });

            return array;
        }

        public static void PrintArray(float[] array, int size)
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
}
