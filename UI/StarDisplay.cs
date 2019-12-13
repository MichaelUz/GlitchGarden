using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
    [SerializeField] int stars = 100;
    Text starText;
    

    bool canAdd = true;

    private void Start()
    {
        UpdateDisplay();
    }


    //-----------------------------------------------------Helper methods-------------------------------------------

    
    //Updates the display text
    private void UpdateDisplay()
    {
        starText = GetComponent<Text>();
        starText.text = stars.ToString();
    }

    //Adds stars and make sure total stars doesn't go above 999
    public void AddStars(int starsToAdd)
    {
        if (stars + starsToAdd > 999)
        {
            stars = 999;
            canAdd = false;
            UpdateDisplay();
        }
        if (canAdd)
        {
            stars += starsToAdd;
            UpdateDisplay();
        }
        
    }

    //Spends stars
    public void SpendStars(int starsToSpend)
    {
        if(stars >= starsToSpend)
        {
            canAdd = true;
            stars -= starsToSpend;
            UpdateDisplay();
        }
        else
        {
            //Tell us that we don't have enough stars
        }
    }

    //Getter for the stars
    public int getStars() { return stars; }

    //Setter for the stars
    public void SetStars(int stars) { this.stars = stars; }
}
