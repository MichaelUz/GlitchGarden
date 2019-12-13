using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scarecrow : Defender
{
    [SerializeField] private float lifetime;
    private float timeElapsed;


    new private void Start()
    {
        base.Start();
        ControlSpawner(false);
    }

    private void Update()
    {
        //Destroy our scarecrow after certain amount of time
        timeElapsed += Time.deltaTime;
        if(timeElapsed > lifetime)
        {
            ControlSpawner(true);
            Die();
        }

    }

    //Override the empower method to double our lifetime
    public override void empower()
    {
        base.empower();
        lifetime *= 2;
    }

    //Either stop the spawner on our lane from spawning or tell it it can start spawning again
    private void ControlSpawner(bool val)
    {
        string command;

        if(val == true) { command = "start"; }
        else { command = "stop"; }
        
        GameObject spawnerParent = GameObject.FindObjectOfType<AttackerSpawner>().transform.parent.gameObject;
        int yPosToChildIndex = Mathf.RoundToInt(transform.position.y) - 1;
        AttackerSpawner spawner = spawnerParent.transform.GetChild(yPosToChildIndex).gameObject.GetComponent<AttackerSpawner>();
        spawner.SetStart(val);
        spawner.controlSpawnCoroutine(command);
    }
}
