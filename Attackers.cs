using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Attackers : MonoBehaviour
{
    private Attacker[] attackTeam = new Attacker[0];
    
    //Getter for Attack team
    public Attacker[] getAttackTeam() { return attackTeam; }


    private void OnEnable()
    {
        SceneManager.sceneLoaded += SceneFinishedLoading;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= SceneFinishedLoading;
    }

    //Getter for size 
    public int getSize()
    {
        int size = 0;
        foreach(Attacker attacker in attackTeam)
        {
            if(attacker != null) size++;
        }
        return size;
    }

    //Sort attacking team
    public void sort()
    {
        for(int i = 0; i < getSize(); i++)
        {
            for (int j = i+1; j < getSize(); j++)
            {
                if (attackTeam[i].getSpawnProbability() > attackTeam[j].getSpawnProbability())
                {
                    Attacker temp = attackTeam[i];
                    attackTeam[i] = attackTeam[j];
                    attackTeam[j] = temp;
                }
            }
        }
    }

    //Setter for attack team
    public void SetAttackTeam(Attacker[] attackTeam)
    {
        this.attackTeam = attackTeam;
    }

    private void SceneFinishedLoading(Scene scene , LoadSceneMode mode)
    {
        sort();
    }

}
