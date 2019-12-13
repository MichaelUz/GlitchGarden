using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tumblejoy : Attacker
{

    [SerializeField] private GameObject smokeEffect;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Defender>() == null)
        {
            return;
        }
        collision.GetComponent<Defender>().Die();
    }

    //kills off our tublge joy
    public override void Die()
    {
        Destroy(gameObject.transform.parent.gameObject);
    }

    //Makes smoke appear behind the tumblejoy
    public void InstantiateSmokeEffect()
    {
        GameObject obj = Instantiate(smokeEffect, gameObject.transform);
        obj.transform.position = transform.position + new Vector3(0.45f, 0, 0);
    }
}
