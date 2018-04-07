using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 声音系统
/// </summary>
[DisallowMultipleComponent]
public class AudioSystem : MonoBehaviour
{
    //参数--------------------------------
    [System.Serializable]
    public struct Setting
    {
        [Header("音效音量")]
        [Range(0, 1.0f)]
        public float soundVolumn;

        [Header("音乐音量")]
        [Range(0, 1.0f)]
        public float musicVolumn;

        /// <summary>
        /// 音乐淡出时间（秒）
        /// </summary>
        [SerializeField]
        [Header("音乐淡出时间")]
        [Range(0.1f, 2.0f)]
        public float musicFadeOutTime;
    }
    [Header("【声音系统】")]
    [Header("参数设置：")]
    public Setting setting;

    private void Reset()
    {
        setting.musicVolumn = 1.0f;
        setting.soundVolumn = 1.0f;
        setting.musicFadeOutTime = 1.0f;
    }

    //属性--------------------------------
    /// <summary>
    /// 用于标记bgm播放器
    /// </summary>
    private AudioSource musicSource = null;



    //方法--------------------------------
    /// <summary>
    /// 播放音效
    /// </summary>
    /// <param name="audio">要播放的音效</param>
    public void Play(AudioClip audio)
    {
        StartCoroutine(play(audio));
    }
    private IEnumerator play(AudioClip audio)
    {
        AudioSource source =
        gameObject.AddComponent<AudioSource>();
        source.clip = audio;
        source.volume = setting.soundVolumn;
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
        StartCoroutine(playMusic(music));
    }
    private IEnumerator playMusic(AudioClip music)
    {
        if (musicSource != null)
        {
            //已有bgm则淡出
            float volumn = setting.musicVolumn;
            while (volumn > 0)
            {
                musicSource.volume = volumn;
                volumn -= setting.musicVolumn * Time.deltaTime / setting.musicVolumn;
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
            musicSource = gameObject.AddComponent<AudioSource>();
            musicSource.clip = music;
            musicSource.volume = setting.musicVolumn;
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
        setting.soundVolumn = volumn;
    }

    /// <summary>
    /// 设置音乐音量，并即时应用设置好的音乐音量
    /// </summary>
    /// <param name="volumn">音量（0.0~1.0）</param>
    public void SetMusicVolumn(float volumn)
    {
        setting.musicVolumn = volumn;
        musicSource.volume = volumn;
    }
}
