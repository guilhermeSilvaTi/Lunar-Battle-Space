using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sound : MonoBehaviour
{
    [SerializeField]
    AudioSource music;

    [SerializeField]
    AudioSource[] SFX;

    private void Start()
    {
        SetValueSound();
    }

    private void SetValueSound()
    {
        music.volume = StatesGame.GetVolumeMusic();
        foreach (var item in SFX)
         item.volume = StatesGame.GetVolumeFX();
    }

    public void ChangeMusic(Slider sliderValue)
    {
        StatesGame.SetVolumeMusic(sliderValue.value);
        music.volume = sliderValue.value;
    }
    public void ChangeFX(Slider sliderValue)
    {
        StatesGame.SetVolumeFX(sliderValue.value);
        foreach (var item in SFX)
            item.volume = sliderValue.value;
    }
}
