using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSlider : MonoBehaviour
{
    enum SliderType
    {
        SOUND_EFFECT,
        BGM
    }

    [SerializeField]
    SliderType sliderType;

    Slider slider;
    
    void Start()
    {
        slider = GetComponent<Slider>();
        
        if(sliderType == SliderType.SOUND_EFFECT)
        {
            slider.value = SoundManager.Instance.SoundEffectVolume;
            slider.onValueChanged.AddListener(
                delegate{
                    SoundManager.Instance.setSoundEffectVolume(slider.value);
                });
        }
        else if(sliderType == SliderType.BGM)
        {
            slider.value = SoundManager.Instance.BGMVolume;
            slider.onValueChanged.AddListener(
                delegate {
                    SoundManager.Instance.setBackGroundMusicVolume(slider.value);
                });
        }
    }

}
