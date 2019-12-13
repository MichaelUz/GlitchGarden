using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{

    public static int num;

    [Range(0f,5f)] [SerializeField] protected float currentSpeed = 1f;
    [SerializeField] protected int health = 10;
    [SerializeField] protected int damage;
    [SerializeField] protected float spawnProbability;
    [SerializeField] protected float offset;
    [SerializeField] protected bool shouldMove = true;
    protected Animator anim;
    protected Defender currentTarget;
    protected GameGrid grid;


    protected void Start()
    {
        num++;
        transform.position = new Vector3(transform.position.x, transform.position.y + offset, transform.position.z);
        anim = GetComponent<Animator>();
        grid = GameObject.FindObjectOfType<GameGrid>();
    }

    private void Update()
    {
        Move();
    }

    

    //Helper Methods --------------------------------------------------------------------------

    //Move attacker

    protected virtual void Move()
    {
        if (shouldMove)
        {
            transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        }
    }

    //Make attacker attack 
    protected virtual void Attack()
    {
        anim.SetBool("shouldAttack", true);
    }

    //Stop attacking
    protected virtual void stopAttack()
    {
        anim.SetBool("shouldAttack", false);
    }

    //Deals damage to us
    public void dealDamage(int damage)
    {
        health -= damage;
        if (health <= 0) { Die(); }
    }

    //Hurts defender
    public void damageDefender()
    {   if(currentTarget !=null)
        {
            currentTarget.loseHealth(damage);
        }
    }

    //Kills off our Attacker
    public virtual void Die()
    {
        shouldMove = false;
        StartCoroutine(DieCoroutine());
    }

    //Makes attacker jump
    protected virtual void Jump()
    {
        //Jump
    }

    //Coroutine that kills attacker
    private IEnumerator DieCoroutine()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetTrigger("Die");
        yield return new WaitForSeconds(0.5f);
        num--;
        Destroy(gameObject);
    }
    
    

    //---------------------------------------------Setters---------------------------------------------------
    
    //Setter for our health
    public void setHealth(int newHealth){ health = newHealth; }

    //Setter for our shouldMove
    public void setShouldMove(bool newVal) { shouldMove = newVal; }

    //Setter for our current speed
    public void setCurrentSpeed(float speed)
    {
        currentSpeed = speed;
    }


    //---------------------------------------------Getters-------------------------------------------------------

    //Getter for ourHealth
    public int getHealth() { return health; }

    //Getter for shouldMove
    public bool getShouldMove() { return shouldMove; }

    //Gets spawn probability 
    public float getSpawnProbability() { return spawnProbability; }

    //Get damage
    public  int GetDamage() { return damage; }
}
