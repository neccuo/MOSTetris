using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameSounds : MonoBehaviour
{
    public float defaultMusicPitch = 1.0f;
    public float loseMusicPitch = 0.67f;

    private SoundManager _soundManager;

    void Start()
    {
        _soundManager = SoundManager.instance;
        SetMusicPitchToDefault();
    }

    public void SetMusicPitchByMoveRate(float moveRate)
    {
        float speed;
        float x1 = 0.1f, x2 = 0.0025f;
        float y1 = 1.0f, y2 = 1.2f;
        speed = y2 + (moveRate-x2)*(y1-y2)/(x1-x2);

        _soundManager.SetMusicPitch(speed);
    }

    public void SetMusicPitchToDefault()
    {
        _soundManager.SetMusicPitch(defaultMusicPitch);
    }

    public void SetMusicPitchToLose()
    {
        _soundManager.SetMusicPitch(loseMusicPitch);
    }

    public void PlayHit()
    {
        _soundManager.PlayHitSound();
    }

    

    void Update()
    {
        
    }
}
