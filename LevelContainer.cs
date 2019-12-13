using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelContainer : MonoBehaviour
{
    //Contains Level object
    private Level currentLevel;
    public static LevelContainer levelContainer;


    private void Awake()
    {
        if(levelContainer == null)
        {
            levelContainer = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    //Setter for level 
    public void SetLevel(Level level)
    {
        currentLevel = level;
    }

    //Getter for level
    public Level GetLevel()
    {
        return currentLevel;
    }
}
