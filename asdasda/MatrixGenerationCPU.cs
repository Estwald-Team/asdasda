using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asdasda
{
    public class MatrixGenerationCPU
    {
        public static float[] GenerateArrayParallel(int length, float fillValue)
        {
            float[] array = new float[length];

            Parallel.For(0, length, i =>
            {
                array[i] = fillValue;
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
