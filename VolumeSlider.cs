using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    Slider volumeSlider;

    private void Start()
    {
        volumeSlider = GetComponent<Slider>();
        volumeSlider.value = FindObjectOfType<AudioSource>().volume;
    }

    //Returns the current value of the volume slider
    public float getValue()
    {
        return volumeSlider.value;
    }
}
