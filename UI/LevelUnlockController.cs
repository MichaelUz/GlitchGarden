using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUnlockController : MonoBehaviour
{
    private Dictionary<int,bool> levelUnlockInfo = new Dictionary<int,bool>();

    private void Awake()
    {
        InitializeLevelUnlockInfo();
    }

    private void Start()
    {
        UpdateButtonsInteractable();
    }

    //Initializes the dictionary
    private void InitializeLevelUnlockInfo()
    {
        levelUnlockInfo = GameObject.FindObjectOfType<UnlockingManager>().GetLevelUnlock();
    }


    //Unlock a level
    public void UnlockLevel(int index)
    {
        levelUnlockInfo[index] = true;
        UpdateButtonsInteractable();
    }

    //Update Buttons interactable value
    public void UpdateButtonsInteractable()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Button button = transform.GetChild(i).gameObject.GetComponent<Button>();
            button.interactable = levelUnlockInfo[i + 1];
        }
    }
}
