using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OptionsButtons : MonoBehaviour
{
    [SerializeField] Button muteMusicButton;
    [SerializeField] Button muteSFXButton;


    void Start()
    {
        muteMusicButton.onClick.AddListener(SoundManager.instance.ToggleMusic);
        muteSFXButton.onClick.AddListener(SoundManager.instance.ToggleSFX);
    }

}
