using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] Color disabledColor;
    [SerializeField] Defender defenderPrefab;
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] TextMesh costDisplay;
    [SerializeField] int cost;
    [SerializeField] int id;

    Defenders defenders;
    Defender[] myTeam;


    //Initialize Defender Button
    private void Start()
    {
        //Initialize my Team
        defenders = GameObject.FindObjectOfType<Defenders>();
        myTeam = defenders.getMyTeam();

        //Initialize Button
        Initialize();
        
    }

    private void OnMouseDown()
    {
        if( TimeManager.canPlace == false)
        {
            return;
        }

        //Get all the buttons in our defender selector and set them to be greyed out once this butotn is selected
        var buttons = FindObjectsOfType<DefenderButton>();
        foreach(DefenderButton button in buttons)
        {
            SpriteRenderer otherSpriteRender = button.gameObject.GetComponent<SpriteRenderer>();
            if(otherSpriteRender)
            {
                otherSpriteRender.color = disabledColor;
            }
        }

        //Now set this button's color to be white and set the selected defender
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if(spriteRenderer)
        {
            spriteRenderer.color = Color.white;
            DefenderSpawner.defender = defenderPrefab;
        }
    }

    //----------------------------------------------------Helper Methods-------------------------------------------

    //Initializes this DefenderButton
    private void Initialize()
    {
        if(myTeam[id] != null)
        {
            //Sprite
            sprite = GetComponent<SpriteRenderer>();
            sprite.sprite = myTeam[id].gameObject.GetComponent<SpriteRenderer>().sprite;

            //cost
            cost = myTeam[id].gameObject.GetComponent<Defender>().getStarCost();

            //Cost Display
            costDisplay = GetComponentInChildren<TextMesh>();
            costDisplay.text = cost.ToString();

            //Defender Prefab
            defenderPrefab = myTeam[id];
        }
        else
        {
            sprite = GetComponent<SpriteRenderer>();
            sprite.sprite = null;
            costDisplay = GetComponentInChildren<TextMesh>();
            costDisplay.text = "";
            defenderPrefab = null;
        }
    }
}
