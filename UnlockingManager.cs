using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockingManager : MonoBehaviour
{
    private Dictionary<string, bool> defUnlock = new Dictionary<string, bool>();
    private Dictionary<string, bool> attackUnlock = new Dictionary<string, bool>();
    private Dictionary<int, bool> levelUnlock = new Dictionary<int, bool>();


    private void Awake()
    {
        Initialization();
    }

    //Method that initializes the dictionaries
    private void Initialization()
    {
        //Initialize defUnlock
        defUnlock.Add("Trophy", true);
        defUnlock.Add("Cactus" , true);
        defUnlock.Add("Gnome", false);
        defUnlock.Add("Gravestone", false);
        defUnlock.Add("Scarecrow", false);
        defUnlock.Add("Butterfly", false);
        //...

        //Initialize attackUnlock
        attackUnlock.Add("Lizard", true);
        attackUnlock.Add("Fox", false);
        attackUnlock.Add("Tumblejoy", false);
        attackUnlock.Add("Jabba", false);
        //...


        //Initialize levelUnlock
        levelUnlock.Add(1, true);
        levelUnlock.Add(2, false);
        levelUnlock.Add(3, false);
        levelUnlock.Add(4, false);
        levelUnlock.Add(5, false);
        levelUnlock.Add(6, false);
        //..

    }

    //Setter for value in defUnlock
    public void SetDefUnlock(string key , bool boolean)
    {
        if (!defUnlock.ContainsKey(key))
        {
            Debug.LogError("Key provided to SetDefUnlock() is invalid.");
            return;
        }
        defUnlock[key] = boolean;
    }

    //Setter for value in levelUnlock
    public void SetLevelUnlock(int key , bool value)
    {
        levelUnlock[key] = value;
    }


    //Setter for value in attackUnlock
    public void SetAttackUnlock(string key , bool boolean)
    {
        
        attackUnlock[key] = boolean;
    }

    //Get defUnlock Dictionary
    public Dictionary<string , bool> GetDefUnlock()
    {
        return defUnlock;
    }

    //Get attackUnlock Dictionary
    public Dictionary<string , bool> GetAttackUnlock()
    {
        return attackUnlock;
    }

    //Get levelUnlock dictionary
    public Dictionary<int , bool> GetLevelUnlock()
    {
        return levelUnlock;
    }
}
