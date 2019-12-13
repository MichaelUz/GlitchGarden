using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    const string MASTER_VOLUME_KEY = "master volume";
    const string TUTORIAL_BOOLEAN_KEY = "Tutorial done";
    const float MIN_VOLUME = 0f;
    const float MAX_VOLUME = 1f;
    bool tutorialDone = false;


    

    //Sets Master volume
    public static void SetMasterVolume(float volume)
    {
        if (volume >= MIN_VOLUME && volume <= MAX_VOLUME)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }
        else
        {
            Debug.LogError("Volume set to player prefs is out of bounds.");
        }
    }

    //Gets master volume
    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    //Sets tutorialDone
    public static void SetTutorialDone(bool val)
    {
        if (val == true)
        {
            PlayerPrefs.SetInt(TUTORIAL_BOOLEAN_KEY, 1);
        }

        if (val == false)
        {
            PlayerPrefs.SetInt(TUTORIAL_BOOLEAN_KEY, 0);
        }
    }

    //Gets tutorialDone
    public static bool GetTutorialDone()
    {
       if (PlayerPrefs.GetInt(TUTORIAL_BOOLEAN_KEY) == 0)
        {
            return false;
        }
        
       if(PlayerPrefs.GetInt(TUTORIAL_BOOLEAN_KEY) == 1)
        {
            return true;
        }
        return false;
    }
}
