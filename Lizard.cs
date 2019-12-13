using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard : Attacker
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.GetComponent<Defender>())
        {
            currentTarget = collision.gameObject.GetComponent<Defender>();
            Attack();
        }
    }

    protected void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Defender>())
        {
            currentTarget = null;
            stopAttack();
        }
    }


}
