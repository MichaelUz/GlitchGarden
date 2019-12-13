using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Range(0f, 5f)] [SerializeField] float speed = 1f;
    private int damage;


    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Attacker>())
        {
            colAttacker(collision.GetComponent<Attacker>());
            Destroy(gameObject);
        }
    }

    private void colAttacker(Attacker obj)
    {
        obj.dealDamage(damage);
    }

    //setter for the damage
    public void setDamage(int newDamage)
    {
        damage = newDamage;
    }
}
