using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightMiniDisplay : MonoBehaviour
{
    [SerializeField]private Image defenderImage;
    [SerializeField]private InputField indexInput;
    [SerializeField] private GameObject aboutPanel;
    private Defender hoveredDefender;
    private EntityInformation info;

    private void Start()
    {
        defenderImage.sprite = null;
        defenderImage.color = new Color32(255, 255, 255, 0);
    }


    //Setter for the image sprite
    public void SetImageSprite(Sprite newSprite)
    {
        defenderImage.sprite = null;
        defenderImage.sprite = newSprite;
    }

    //Defender selector
    public void SelectDefender(Defender def)
    {
        hoveredDefender = def;
        SetImageSprite(hoveredDefender.getIcon());
        defenderImage.color = Color.white;
    }

    //Update current info
    public void UpdateInfo(EntityInformation info)
    {
        this.info = info;
    }

    
    //Method called when player presses select button
    public void Select()
    {
        if(hoveredDefender == null || hoveredDefender.GetComponent<Trophy>())
        {
            return;
        }

        MyTeamDisplay myTeamDisplay = GameObject.FindObjectOfType<MyTeamDisplay>();
        if(int.TryParse(indexInput.text , out int j))
        {
            if( j < 0 || j > 4)
            {
                return;
            }
            myTeamDisplay.addDefender(j, hoveredDefender);
        }
        
    }

    //Method called when player presses about button
    public void About()
    {
        if(info == null)
        {
            return;
        }
        
        Canvas canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        GameObject.FindObjectOfType<MenuController>().OpenPanel(aboutPanel);
        Invoke("UpdateInfoDisplay",0.01f);
    }

    //Method that updates the image and text of the about panel so it opens up without the player having to select defender again
    private void UpdateInfoDisplay()
    {
        GameObject.FindObjectOfType<InformationPanel>().SetUp(info);
    }
}
