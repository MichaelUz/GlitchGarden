using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave
{
    private float minSpawnDelay;
    private float maxSpawnDelay;
    private int maxSize;
    private int index;

    //Constructor
    public Wave(float minSpawnDelay , float maxSpawnDelay , int index)
    {
        this.minSpawnDelay = minSpawnDelay;
        this.maxSpawnDelay = maxSpawnDelay;
        this.index = index;
    }

    //Getter for minimum Spawn delay
    public float getMinSpawnDelay() { return minSpawnDelay; }
   

    //Getter for maximum spawn delay
    public float getMaxSpawnDelay() { return maxSpawnDelay; }
   

    //Getter for our size
    public int GetMaxSize() { return maxSize; }
   

    //Getter for our index
    public int GetIndex() { return index; }

    //Setter for our size
    public void SetMaxSize(int size){ this.maxSize = size; }

    // Prints current wave
    public void PrintWave()
    {
        Debug.Log("current wave index : " + index + " || " + minSpawnDelay + ", " + maxSpawnDelay +" || max wave size : " + maxSize );
    }
}
