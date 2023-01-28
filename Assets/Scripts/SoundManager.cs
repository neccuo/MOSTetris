using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource musicPlayer;
    public AudioSource sfx;
    public AudioClip song;
    public AudioClip hit;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
            // musicPlayer.volume = 0.1f;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start() 
    {
        musicPlayer.clip = song;
        musicPlayer.Play();
    }

    public void MuteMusic()
    {
        musicPlayer.mute = !musicPlayer.mute;
    }

    public void PlayHitSound()
    {
        sfx.clip = hit;
        sfx.Play();
    }

    public void SetMusicPitch(float pitch)
    {
        musicPlayer.pitch = pitch;
    }
}
