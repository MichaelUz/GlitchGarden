using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class myTeamSelector : MonoBehaviour
{
    private Dictionary<string , Button> myButtons = new Dictionary<string , Button>();


    private void Start()
    {
        InitializeButtons();
    }

    //Initialize list of button
    private void InitializeButtons()
    {
        Dictionary<string, bool> defUnlock = FindObjectOfType<UnlockingManager>().GetDefUnlock();

        for ( int i = 0; i < transform.childCount; i++)
        {
            GameObject child = transform.GetChild(i).gameObject;
            if (child.GetComponent<teamSelectorButton>().GetMyDef() == null) { continue; }
            string defName = child.GetComponent<teamSelectorButton>().GetMyDef().name;
            myButtons.Add(defName , child.GetComponent<Button>());
            SetEnabled(defUnlock[defName], defName);
        }
    }

    //Setter for enabled
    public void SetEnabled(bool interactable , string def)
    {
        if (!myButtons.ContainsKey(def)) { return; }

        myButtons[def].interactable = interactable;
    }
}
