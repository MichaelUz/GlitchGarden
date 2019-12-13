using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gnome : Defender
{
    [SerializeField] GameObject explosionVFX;
    [SerializeField] float delayToExplosion;
    protected int numExplosions = 1;

    
    //explode when we collide with an attacker
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Attacker>() != null)
        {
            StartCoroutine(explode(delayToExplosion, collision));
        }
    }

    //------------------------------------Helper methods-----------------------------------------------------

    //This IEnumerator handles the explosion of the gnome and as well as the colliding attacker.
    private IEnumerator explode(float delay , Collider2D collision)
    {
        numExplosions--;
        Vector3 location = new Vector3(transform.position.x + 0.4f, transform.position.y, transform.position.z);
        GameObject vfx = Instantiate(explosionVFX, location, Quaternion.identity);
        if(collision.gameObject.GetComponent<Attacker>())
        {
            collision.gameObject.GetComponent<Attacker>().Die();
        }
        yield return new WaitForSeconds(delay);
        Destroy(vfx);

        //Stay alive if we have explosions left
        if(numExplosions <= 0 )
        {
            Die();
            Destroy(gameObject);
        } 
    }

    //Gets Damage
    public override int GetDamage()
    {
        return 9999999;
    }

    //Override the empowered method to add more number of explosions
    public override void empower()
    {
        Debug.Log(gameObject.name + " is being empowered");
        numExplosions = 3;
    }
}
