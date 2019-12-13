using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    private List<GameObject> menuPanels = new List<GameObject>();
    private GameObject currentPanel;

    private void Start()
    {
        canvas = GameObject.FindObjectOfType<Canvas>();
    }


    //Opens up  panel
    public void OpenPanel( GameObject panel)
    {
        GameObject instantiatedPanel = Instantiate(panel, canvas.transform);
        if (menuPanels.Contains(instantiatedPanel))
        {
            menuPanels.Remove(instantiatedPanel);
        }
        menuPanels.Insert(0, instantiatedPanel);
    }

    //Goes back to previously opened panel
    public void OpenPreviousPanel()
    {
        if (menuPanels.Count <= 0)
        {
            return;
        }

        else if (menuPanels.Count == 1)
        {
            Destroy(menuPanels[0]);
            menuPanels.RemoveAt(0);
            return;
        }

        Destroy(menuPanels[0]);
        menuPanels.RemoveAt(0);
        //OpenPanel(menuPanels[0]);
    }




}
