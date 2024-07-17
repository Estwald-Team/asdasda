using ComputeSharp;
using System;

[ThreadGroupSize(32,32,1)]
[RequiresDoublePrecisionSupport]
[GeneratedComputeShaderDescriptor]
public readonly partial struct RandomShader : IComputeShader
{
  
    private readonly ReadWriteBuffer<double> C;
    private readonly int width;

    private double Random(int seed)
    {
        uint x = (uint)seed;
        x = (x ^ 0xDEADBEEF) + (x << 4);
        x = x ^ (x >> 16);
        return (x & 0xFFFFFF) / (double)0x1000000 * 10.0;
    }
    public RandomShader(ReadWriteBuffer<double> C, int width)
    {
        
        this.C = C;
        this.width = width;
    }
    public void Execute()
    {
        int id = ThreadIds.X;

        C[id] = Random(id);
    }
}
