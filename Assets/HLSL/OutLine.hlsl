void OutLine_float(UnityTexture2D MainTex, float2 UV, out float4 Result)
{
    float4 baseColor = MainTex.Sample(MainTex.samplerstate, UV); // Shader Graph 호환
    float2 imageSize = float2(1920, 1080);
    float weight = 1;
    float4 outlineColor = float4(1, 0, 0, 1); 
    float count = 0;

    [branch]
    if (baseColor.a > 0.0f)
    {
        Result = baseColor;
        return;
    }

    for (int i = -1; i <= 1; i++)
    {
        for (int j = -1; j <= 1; j++)
        {
            float2 offset = (float2(j, i) / imageSize) * weight;
            count += MainTex.Sample(MainTex.samplerstate, UV + offset).a;
        }
    }
    [branch]
    if (count > 0 && count < 9)
    {
        Result = outlineColor;
    }
    else
    {
        Result = baseColor; 
    }
}