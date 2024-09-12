using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YTH_SoundManager : MonoBehaviour
{
    public static YTH_SoundManager Instance { get; private set; }

    [SerializeField] AudioSource bgm;
    [SerializeField] AudioSource sfx;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayBGM(AudioSource clip)
    {
        //bgm.clip = clip;
        bgm.Play();
    }

    public void StopBGM()
    {
        if (bgm.isPlaying == false)
            return;

        bgm.Stop();
    }

    public void PauseBGM()
    {
        if (bgm.isPlaying == false)
            return;

        bgm.Pause();
    }

    public void SetBGM(float volume, float pitch = 1f)
    {
        bgm.volume = volume;
        bgm.pitch = pitch;
    }

    public void PlaySFX(AudioClip clip)
    {
        sfx.PlayOneShot(clip); //음원파일 동시에 재생
    }
}
