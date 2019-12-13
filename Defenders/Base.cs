using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Base : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] int healthToLose;
    [SerializeField] GameObject losePanel;
    [SerializeField] GameObject overlayCanvas;
    private Slider slider;
    public static bool lost = false;

    //Initialization
    private void Start()
    {
        slider = GameObject.Find("HealthSlider").GetComponent<Slider>();
        lost = false;
    }

    //Update our health whenever we collide with enemy and destroy attacker.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Attacker>())
        {
            hit();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Attacker>())
        {
            collision.gameObject.GetComponent<Attacker>().Die();
            Attacker.num--;
        }
    }

    //Method that reduces our health
    private void hit()
    {   
        if( health - healthToLose <= 0) {
            slider.value = 0;
            health = 0;
            Dead();
        }
        else
        {
            float sliderPercentage = (health - healthToLose) / 100.0f;
            slider.value = sliderPercentage;
            health -= healthToLose;
        }

        
        
    }

    //Method that virtually pauses the game and destroys all attackers from the scene.
    private void Dead()
    {
        lost = true;
        GameObject canvas = GameObject.Find("Canvas");
        Instantiate(losePanel, overlayCanvas.transform);
        TimeManager.VirtualPause();
        foreach (Attacker attacker in FindObjectsOfType<Attacker>())
        {
            Destroy(attacker.gameObject);
        }
    }
}
