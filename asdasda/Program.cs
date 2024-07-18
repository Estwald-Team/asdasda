using asdasda;
using MathNet.Numerics.LinearAlgebra.Single;
using System.Diagnostics;

int size = 1000;

// Time CPU matrix generation
var cpuWatch = Stopwatch.StartNew();
float[] cpuArray = MatrixGenerationCPU.GenerateArrayParallel(size * size,2.0f);
cpuWatch.Stop();
Console.WriteLine($"CPU Parallel.For execution time: {cpuWatch.ElapsedMilliseconds} ms");

// Time GPU matrix generation
var gpuWatch = Stopwatch.StartNew();
float[] gpuArray = MatrixGenerationGPU.GenerateMatrixGPU(size,2.0f);
gpuWatch.Stop();
Console.WriteLine($"GPU ComputeSharp execution time: {gpuWatch.ElapsedMilliseconds} ms");

var mathNetWatch = Stopwatch.StartNew();
var mathNetArray = DenseMatrix.Create(1000, 1000, 2.0f);
mathNetWatch.Stop();
Console.WriteLine($"Math.NET Numerics execution time: {mathNetWatch.ElapsedMilliseconds} ms");
