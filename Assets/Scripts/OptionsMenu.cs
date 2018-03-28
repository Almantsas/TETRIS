using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour {

    public AudioMixer audioMixer;
    public Slider MusicSlider;
    public Slider EffectsSlider;

    void Start()
    {
        MusicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        EffectsSlider.value = PlayerPrefs.GetFloat("EffectsVolume");
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", volume);
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    public void SetEffectsVolume(float volume)
    {
        audioMixer.SetFloat("EffectsVolume", volume);
        PlayerPrefs.SetFloat("EffectsVolume", volume);
    }
}
