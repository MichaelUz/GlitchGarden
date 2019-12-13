using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyTeamDisplay : MonoBehaviour
{
    //private List<Sprite> mySprites = new List<Sprite>(6);
    private Defenders defenders;

    private void Start()
    {
        defenders = GameObject.FindObjectOfType<Defenders>();

        //Initialize our list of sprites
        //Initially we set up our private Liste of sprites based on the defenders in the defenders script.
        int index = 0;
        foreach(Defender defender in defenders.getMyTeam())
        {
            if(defender != null  && defender.gameObject.GetComponent<Trophy>())
            {
                continue;
            }

            if(defender == null)
            {
                transform.GetChild(index).GetComponent<Image>().sprite = null;
                index++;
                continue;
            }
            transform.GetChild(index).GetComponent<Image>().sprite = defender.getIcon();
            index++;

        }


        //Now we display those sprites in our myTeam display
        updateDisplay();
    }

    //Method that lets us add a Defender to myTeam at a specific index
    public void addDefender(int index , Defender def)
    {
        defenders.addDefender(index, def);
        transform.GetChild(index-1).GetComponent<Image>().sprite = null;
        transform.GetChild(index-1).GetComponent<Image>().sprite = def.getIcon();
        updateDisplay();
    }

    //Method that updates the display of myTeam
    public void updateDisplay()
    {
        Defender[] team = defenders.getMyTeam();
        for (int i = 0; i < team.Length; i++)
        {
            //Ignore defender if it is null or it is the first one (trophy)
            if(team[i] == null || i==0)
            {
                continue;
            }
            GameObject child = transform.GetChild(i-1).gameObject;
            if(child.GetComponent<Image>().sprite == null) { continue; }
            child.GetComponent<Image>().color = new Color32(255,255,255,255);
            child.GetComponent<Image>().sprite = team[i].getIcon();
        }
    }

}
