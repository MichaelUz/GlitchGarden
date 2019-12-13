using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butterfly : Defender
{
    ParticleSystem empoweredEffect;
    private Vector3 offSet;

    new private void Start()
    {
        offSet = new Vector3(-0.285f, 0.285f , 0);
        transform.position = transform.position + offSet;
        base.Start();
        empoweredEffect = GetComponentInChildren<ParticleSystem>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.GetComponent<Defender>())
        {
            Defender myDef = collision.GetComponent<Defender>();
            myDef.empower();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //We Die if the defender we're empowering dies.
        if(collision.GetComponent<Defender>())
        {
            Die();
        }
    }

    //Override Die() method , we don't want to remove ourselves ffrom the game grid because we were never in it
    // to begin with.
    public override void Die()
    {
        Destroy(gameObject);
    }
}
