using ComputeSharp;
using System;

[ThreadGroupSize(32,32,1)]
[RequiresDoublePrecisionSupport]
[GeneratedComputeShaderDescriptor]
public readonly partial struct RandomShader : IComputeShader
{
  
    private readonly ReadWriteBuffer<float> C;
    private readonly int width;
    private readonly float value;
  
    public RandomShader(ReadWriteBuffer<float> C, int width, float value)
    {
        
        this.C = C;
        this.width = width;
        this.value = value;
    }
    public void Execute()
    {
        int index = ThreadIds.X;

        C[index] = value;
    }
}
