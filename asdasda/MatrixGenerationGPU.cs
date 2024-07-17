using System;
using ComputeSharp;

class MatrixGenerationGPU
{
    public static float[] GenerateMatrixGPU(int size)
    {
        float[] matrix = new float[size];

        using (ReadWriteBuffer<float> buffer = GraphicsDevice.GetDefault().AllocateReadWriteBuffer<float>(size))
        {
            GraphicsDevice.GetDefault().For(size, new RandomShader(buffer, size));
            buffer.CopyTo(matrix);
        }

        return matrix;
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
