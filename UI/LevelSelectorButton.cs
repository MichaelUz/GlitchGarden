using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectorButton : MonoBehaviour
{
    [SerializeField] Level level;

    public void LoadLevel()
    {
        LevelLoader levelLoader = FindObjectOfType<LevelLoader>();
        LevelContainer levelContainer = FindObjectOfType<LevelContainer>();
        levelContainer.SetLevel(level);
        levelLoader.LoadSceneDelay(0f);
    }
}
