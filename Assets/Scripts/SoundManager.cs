using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource musicPlayer;
    public AudioSource sfxPlayer;
    public AudioClip song;
    public AudioClip hit;

    private string _ppMusicMute = "musicMute";
    private string _ppSFXMute = "sfxMute";


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
            musicPlayer.mute = PlayerPrefs.GetInt(_ppMusicMute, 0) == 1;
            sfxPlayer.mute = PlayerPrefs.GetInt(_ppSFXMute, 0) == 1;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start() 
    {
        musicPlayer.clip = song;
        musicPlayer.Play();
    }

    public void ToggleMusic()
    {
        musicPlayer.mute = !musicPlayer.mute;
        PlayerPrefs.SetInt("musicMute", sfxPlayer.mute ? 1 : 0);
    }

    public void ToggleSFX()
    {
        sfxPlayer.mute = !sfxPlayer.mute;
        PlayerPrefs.SetInt("sfxMute", sfxPlayer.mute ? 1 : 0);
    }

    public void PlayHitSound()
    {
        sfxPlayer.clip = hit;
        sfxPlayer.Play();
    }

    public void SetMusicPitch(float pitch)
    {
        musicPlayer.pitch = pitch;
    }
}
