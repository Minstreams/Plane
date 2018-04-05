using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 场景管理系统
/// </summary>
[DisallowMultipleComponent]
public class SceneSystem : MonoBehaviour
{
    //参数--------------------------------
    [System.Serializable]
    public struct Setting
    {

    }
    [Header("【场景管理系统】")]
    [Header("参数设置：")]
    public Setting setting;

    //属性--------------------------------
    private string currentSceneName = "";


    //方法--------------------------------
    /// <summary>
    /// 加载并替换游戏场景
    /// </summary>
    /// <param name="sceneName">场景名</param>
    public void LoadScene(string sceneName)
    {
        if (!currentSceneName.Equals(""))
        {
            SceneManager.UnloadSceneAsync(currentSceneName);
        }
        currentSceneName = sceneName;
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }
}
