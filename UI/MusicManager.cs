using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    AudioSource audioSource;
    VolumeSlider volumeSlider;

    private void Awake()
    {
        audioSource = FindObjectOfType<AudioSource>();
        audioSource.volume = PlayerPrefsController.GetMasterVolume();
    }

    private void OnApplicationQuit()
    {
        PlayerPrefsController.SetMasterVolume(FindObjectOfType<AudioSource>().volume);
    }

    public void changeVolume()
    {
        audioSource = FindObjectOfType<AudioSource>();
        volumeSlider = GameObject.FindObjectOfType<VolumeSlider>();
        audioSource.volume = volumeSlider.getValue();
    }
}
