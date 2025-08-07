static const float weights[13] =
{
    0.0561f, 0.1353f, 0.2730f, 0.4868f, 0.7261f, 0.9231f,
	1.0f,
	0.9231f, 0.7261f, 0.4868f, 0.2730f, 0.1353f, 0.0561f
};

void Blur_float(UnityTexture2D MainTex, float2 UV,  out float4 Result)
{
    float4 sum = float4(0, 0, 0, 0);
    float2 imageSize = float2(1920, 1080);
    float2 div = 1.0f / imageSize;
    Result = float4(0, 0, 0, 0);
    
    for (int i = -6; i < 6;i++)
    {
        float2 temp = UV + float2(div.x * i, 0);
        Result += weights[6 + i] * MainTex.Sample(MainTex.samplerstate, temp);
    
        temp = UV + float2(0, div.y * i);
        Result += weights[6 + i] * MainTex.Sample(MainTex.samplerstate, temp);
    
        sum += weights[6 + i] * 2.0f;
        
    }
    Result /= sum;
}