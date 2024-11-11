using UnityEngine;
using UnityEngine.UI;

public class ComputeShaderExample : MonoBehaviour
{
    public ComputeShader computeShader;
    private RenderTexture renderTexture;

    void Start()
    {
        // renderTexture = new RenderTexture(256, 256, 0);ここを以下のように変更．
        renderTexture = new RenderTexture(256, 256, 0, RenderTextureFormat.ARGBFloat);
        renderTexture.enableRandomWrite = true;
        renderTexture.Create();

        computeShader.SetTexture(0, "Result", renderTexture);

        int threadGroupsX = renderTexture.width / 8;
        int threadGroupsY = renderTexture.height / 8;
        computeShader.Dispatch(0, threadGroupsX, threadGroupsY, 1);
        GetComponent<RawImage>().texture = renderTexture;
    }
    void OnDestroy()
    {
        if (renderTexture != null)
            renderTexture.Release();
    }
}
