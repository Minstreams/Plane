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

        /// <summary>
        /// 更新加载进度事件
        /// </summary>
        public event System.Action<float> updateProgress;

        //方法--------------------------------
        /// <summary>
        /// 加载并替换游戏场景
        /// </summary>
        /// <param name="sceneName">场景名</param>
        public void LoadScene(string sceneName)
        {
            
        }

        private IEnumerator loadScene(string sceneName)
        {
            //加载Loading场景
            SceneManager.LoadScene("LoadingScene");

            //卸载原场景
            if (!currentSceneName.Equals(""))
            {
                SceneManager.UnloadSceneAsync(currentSceneName);
            }

            //加载前动画
            //TODO

            //加载新场景
            currentSceneName = sceneName;
            AsyncOperation progress = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

            while (!progress.isDone)
            {
                //播放加载效果
                if (updateProgress != null)
                {
                    //虽然可以把判断置于循环外减少判断次数，不过意义不大，得不偿失
                    updateProgress(progress.progress);
                }
                yield return 0;
            }

            //加载后动画
            //TODO

            //卸载Loading场景
            SceneManager.UnloadSceneAsync("LoadingScene");

            yield return 0;
        }
    }
    public Setting setting;
}
