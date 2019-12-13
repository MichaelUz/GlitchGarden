using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static bool canSpawn = false;
    public static bool canPlace = false;
    [SerializeField] private GameObject overlayCanvas;

    //Sets time Scale
    public void SetTimeScale(float time)
    {
        Time.timeScale = time;
    }

    //Virtual Pause
    public static void VirtualPause()
    {
        canPlace = false;
        canSpawn = false;
    }

    //Virtual Play
    public static void VirtualPlay(bool initial)
    {
        if (initial)
        {
            foreach (AttackerSpawner attackerSpawner in FindObjectsOfType<AttackerSpawner>())
            {
                attackerSpawner.SetStart(true);
            }
        }
        canPlace = true;
        canSpawn = true;
    }
}

   