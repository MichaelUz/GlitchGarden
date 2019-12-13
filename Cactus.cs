using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : Defender
{
    private Animator anim;

    //Initialization 
    new private void Start()
    {
        base.Start();
        anim = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        if(shouldAttack()){ anim.SetTrigger("Attack"); }
        else { anim.SetTrigger("Defend");}
    }

    //--------------------------------------Helper methods-------------------------------------------

    //This method checks if defender should enter attacking state 
    private bool shouldAttack()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 20.0f, ~LayerMask.GetMask("CoreGameArea", "Ignore Raycast"));
        //Debug.Log(hit.collider.name);
        if (hit.collider != null && hit.collider.gameObject.GetComponent<Attacker>())
        { 
            return true;
        }
        return false;
    }

    public override int GetDamage() { return GetComponent<Shooter>().GetDamage(); }
}
