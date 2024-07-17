using System;
using ComputeSharp;

class MatrixGenerationGPU
{
    public static void Main()
    {
        int size = 1000;
        double[] matrix = GenerateMatrixGPU(size);

        Console.WriteLine("Matrix generated using GPU ComputeSharp.");

        // Uncomment to print the matrix (it will be very large)
        // PrintMatrix(matrix);
    }

    public static double[] GenerateMatrixGPU(int size)
    {
        double[] matrix = new double[size];
        using (ReadWriteBuffer<double> buffer = GraphicsDevice.GetDefault().AllocateReadWriteBuffer<double>(size * size))
        {
             GraphicsDevice.GetDefault().For(size * size, new RandomShader(buffer, size));
            buffer.CopyTo(matrix);
        }

        return matrix;
    }

    public static void PrintMatrix(double[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}
