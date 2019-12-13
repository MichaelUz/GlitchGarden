using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{

    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] Attacker attackerPrefab;
    Attackers attackers;
    WaveController level;

    private Attacker[] attackTeam;
    private Coroutine routine;
    private bool start = false;
    private bool startDelay;


    private void Start()
    {
        attackers = GameObject.FindObjectOfType<Attackers>();
        attackTeam = attackers.getAttackTeam();
        level = GameObject.FindObjectOfType<WaveController>();
        startDelay = true;
        
    }

    private void Update()
    {
        if(start == true)
        {
            start = false;
            routine = StartCoroutine(Spawn());
        }
    }

    IEnumerator Spawn()
    {
        if(startDelay)
        {
            startDelay = false;
            yield return new WaitForSeconds(7f);
        }
        yield return new WaitForSeconds(2f);
        while (TimeManager.canSpawn)
        {
            float random = Random.Range(minSpawnDelay, maxSpawnDelay);
            yield return new WaitForSeconds(random);
            SpawnAttacker();
        }
    }



    //Helper methods ---------------------------------------------------------------------------

    //This method instantiates atatckers
    private void SpawnAttacker()
    {
            //Try and instantiate attacker based on probability
        int randomIndex = Mathf.RoundToInt(Random.Range(0, attackers.getSize()));
        float myProb = Random.Range(0f, 1f);
        foreach (Attacker attacker in attackTeam)
        {
            if(attacker == null) { continue; }

            float attackerSpawnProb = attacker.getSpawnProbability();
            //Deal with the fact that Tumblejoy has a holder with the attacker script on it.
            if(attacker.gameObject.GetComponent<Tumblejoy>())
            {
                Transform child = attacker.gameObject.transform.GetChild(0);
                attackerSpawnProb = child.GetComponent<Tumblejoy>().getSpawnProbability();
            }

            if(myProb <= attackerSpawnProb )
            {
                attackerPrefab = attacker;
                instantiateAttacker(attackerPrefab, transform.position, transform.rotation);
                return;
            }
        }
        instantiateAttacker(attackTeam[randomIndex], transform.position, transform.rotation);
            
    }


    //This method instantiates the attacker
    private void instantiateAttacker(Attacker att , Vector3 position , Quaternion rotation)
    {
        Instantiate(att, position, rotation);
        level.addWaveSize(1);
    }

    

    //This method controls the Spawn Coroutine
    public void controlSpawnCoroutine(string command)
    {
        if (command == "start")
        {
            routine = StartCoroutine(Spawn());
        }

        else if (command == "stop")
        {
            StopCoroutine(routine);
        }
        else
        {
            return;
        }
    }

    //Sets the spawn delays
    public void setSpawnDelays(float min , float max)
    {
        minSpawnDelay = min;
        maxSpawnDelay = max;
    }

    //Setter for Start
    public void SetStart(bool val)
    {
        start = val;
    }
}
