using asdasda;
using System.Diagnostics;

int size = 1000;

// Time CPU matrix generation
var cpuWatch = Stopwatch.StartNew();
float[] cpuArray = MatrixGenerationCPU.GenerateArrayParallel(size * size);
cpuWatch.Stop();
Console.WriteLine($"CPU Parallel.For execution time: {cpuWatch.ElapsedMilliseconds} ms");

// Time GPU matrix generation
var gpuWatch = Stopwatch.StartNew();
float[] gpuArray = MatrixGenerationGPU.GenerateMatrixGPU(size);
gpuWatch.Stop();
Console.WriteLine($"GPU ComputeSharp execution time: {gpuWatch.ElapsedMilliseconds} ms");
