using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 声音系统
/// </summary>
[DisallowMultipleComponent]
public class AudioSystem : MonoBehaviour
{
#if UNITY_EDITOR
    [Header("【声音系统】")]
    public EmptyStruct 一一一一一一一一一一一一一一一一一一一一一一一一一一一;
#endif
    [System.Serializable]
    public class Setting
    {
        //参数--------------------------------
        [Header("音效音量")]
        [Range(0, 1.0f)]
        public float soundVolumn = 1.0f;

        [Header("音乐音量")]
        [Range(0, 1.0f)]
        public float musicVolumn = 1.0f;

        /// <summary>
        /// 音乐淡出时间（秒）
        /// </summary>
        [SerializeField]
        [Header("音乐淡出时间")]
        [Range(0.1f, 2.0f)]
        public float musicFadeOutTime = 1.0f;







        //属性--------------------------------
        /// <summary>
        /// 用于标记bgm播放器
        /// </summary>
        private AudioSource musicSource = null;

        /// <summary>
        /// 外层实例
        /// </summary>
        public AudioSystem instance { private get; set; }






        //方法--------------------------------
        /// <summary>
        /// 播放音效
        /// </summary>
        /// <param name="audio">要播放的音效</param>
        public void Play(AudioClip audio)
        {
            instance.StartCoroutine(play(audio));
        }
        private IEnumerator play(AudioClip audio)
        {
            AudioSource source =
            instance.gameObject.AddComponent<AudioSource>();
            source.clip = audio;
            source.volume = soundVolumn;
            source.Play();

            yield return new WaitForSeconds(audio.length);
            Destroy(source);

            yield return 0;
        
        }

        /// <summary>
        /// 播放BGM
        /// </summary>
        /// <param name="music"></param>
        public void PlayMusic(AudioClip music)
        {
            instance.StartCoroutine(playMusic(music));
        }
        private IEnumerator playMusic(AudioClip music)
        {
            if (musicSource != null)
            {
                //已有bgm则淡出
                float volumn = musicVolumn;
                while (volumn > 0)
                {
                    musicSource.volume = volumn;
                    volumn -= musicVolumn * Time.deltaTime / musicVolumn;
                    yield return 0;
                }
                Destroy(musicSource);
            }

            if (music == null)
            {
                musicSource = null;
            }
            else
            {
                musicSource = instance.gameObject.AddComponent<AudioSource>();
                musicSource.clip = music;
                musicSource.volume = musicVolumn;
                musicSource.loop = true;
                musicSource.Play();
            }
            yield return 0;
        }

        /// <summary>
        /// 设置音效音量
        /// </summary>
        /// <param name="volumn">音量（0.0~1.0）</param>
        public void SetSoundVolumn(float volumn)
        {
            soundVolumn = volumn;
        }

        /// <summary>
        /// 设置音乐音量，并即时应用设置好的音乐音量
        /// </summary>
        /// <param name="volumn">音量（0.0~1.0）</param>
        public void SetMusicVolumn(float volumn)
        {
            musicVolumn = volumn;
            musicSource.volume = volumn;
        }
    }
    public Setting setting;

    private void Reset()
    {
        setting.instance = this;
    }
}
