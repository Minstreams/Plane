using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 后处理特效脚本
/// </summary>
[AddComponentMenu("Function/My Post Effect")]
public class MyPostEffect : UnityStandardAssets.ImageEffects.PostEffectsBase {
    [Header("【后处理特效脚本】")]
    [Header("后处理材质")]
    public Material mat;
    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if(mat == null)
        {
            Graphics.Blit(source, destination);
            return;
        }
        Graphics.Blit(source, destination, mat);
    }
}
