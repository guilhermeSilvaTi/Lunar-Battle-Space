using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SliderConfig : MonoBehaviour
{
    [SerializeField]
    Slider sliderMusic;

    [SerializeField]
    Slider sliderFX;

    void Start()
    {
        SliderGetValue();
    }

   private void SliderGetValue()
    {
        sliderMusic.value = StatesGame.GetVolumeMusic();
        sliderFX.value = StatesGame.GetVolumeFX();
    }
}
