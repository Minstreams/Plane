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
#if UNITY_EDITOR
    [Header("【场景管理系统】")]
    public EmptyStruct 一一一一一一一一一一一一一一一一一一一一一一一一一一一;
#endif
    [System.Serializable]
    public class Setting
    {
        //参数--------------------------------




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
    public Setting setting;
}
