using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : Attacker
{

    new private void Start()
    {
        base.Start();
        anim = GetComponentInChildren<Animator>();

        
    }
    //If we collide 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Jump if we collide with gravestone
        Gravestone gravestone = collision.gameObject.GetComponent<Gravestone>();
        if (gravestone != null && canJump(gravestone))
        {
            Jump();
        }
        else
        {
            currentTarget = collision.gameObject.GetComponent<Defender>();
            if(currentTarget != null )
            {
                Attack();
            }
        }
    }

    protected void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.GetComponent<Defender>())
        {
            currentTarget = null;
            stopAttack();
        }
    }
    //Method makes us Jump
    protected override void Jump()
    {
        anim.SetTrigger("Jump");
    }


    //This method will tell us whether or not there is an object behind the gravestone, if there isn't  : we can jump over the gravestone
    protected bool canJump(Gravestone gravestone)
    {
        int x = Mathf.RoundToInt(gravestone.gameObject.transform.position.x) - 1;
        int y = Mathf.RoundToInt(gravestone.gameObject.transform.position.y);

        if (grid.canPlace(x, y , gravestone)) { return true; }
        return false;
    }

    
}
