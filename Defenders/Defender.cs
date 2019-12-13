using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] protected int starCost = 100;
    [SerializeField] protected int health = 100;
    [SerializeField] protected Sprite icon;
    [SerializeField] protected int damage = 0;
    private GameGrid grid;
    protected bool empowered = false;


    protected void Start()
    {
        grid = GameObject.FindObjectOfType<GameGrid>();
    }

    //-----------------------------------Helper Methods--------------------------------------------


    //Get starCost
    public int getStarCost() { return starCost; }

    //Get icon
    public Sprite getIcon() { return icon; }

    //Get damage
    public virtual int GetDamage() { return damage; }

    //Get Health
    public int GetHealth() { return health; }

    //Lose some health
    public virtual void loseHealth(int healthToLose)
    {
        health -= healthToLose;
        if(health <= 0)
        {
            Die();
        }
    }

    //Kill the defender 
    public virtual void Die()
    {
        int x = Mathf.RoundToInt(transform.position.x);
        int y = Mathf.RoundToInt(transform.position.y);
        grid.removeDefender(x, y);
        Destroy(gameObject);
    }


    //Empowers this defender (called when butterfly placed on it)
    public virtual void empower()
    {
        Debug.Log(gameObject.name + " is being empowered");
        damage *= 2;
    }
}
