using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trophy : Defender
{
    [SerializeField] protected int starsToAdd;
    StarDisplay starDisplay;

    new private void Start()
    {
        base.Start();
        starDisplay = GameObject.FindObjectOfType<StarDisplay>();
    }

    //Add stars to the game's star Display
    public void AddStars()
    {
        starDisplay.AddStars(starsToAdd);
    }

    //Override empower method to increase the stars we gain
    public override void empower()
    {
        base.empower();
        starsToAdd *= 2;
    }
}
