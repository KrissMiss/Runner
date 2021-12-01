using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    public AudioSource sound;
    float volSound = 0;
    public Slider slider;

    void Start()
    {
        if (PlayerPrefs.HasKey("Volume"))
        {
            float savedSet = PlayerPrefs.GetFloat("Volume");
            sound.volume = savedSet;
            slider.value = savedSet;
        }
    }

    public void SoundLevel()
    {
        volSound = slider.value;
        sound.volume = volSound;
        PlayerPrefs.SetFloat("Volume", volSound);
        PlayerPrefs.Save();
    }
}
