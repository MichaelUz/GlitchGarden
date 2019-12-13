using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialPanelController : MonoBehaviour
{
    [TextArea(1,8)]
    [SerializeField] string[] inputText;
    [SerializeField] float startDelay;
    [SerializeField] float delayBetweenChar;

    private bool pageEnded = false;
    private int currentTextIndex = 0;
    private Text outputText;

    private void Start()
    {
        TimeManager.VirtualPause();
        outputText = GetComponentInChildren<Text>();
        outputText.text = "";
        StartCoroutine(textAppear(startDelay, delayBetweenChar , currentTextIndex));
    }

    //Coroutine that handles the  appearance of the characters
    IEnumerator textAppear(float startDelay ,  float delayBetweenChar , int index)
    {
        outputText.text = "";
        pageEnded = false;
        if (index == 0)
        {
            yield return new WaitForSeconds(startDelay);
        }

        foreach (char character in inputText[index])
        {
            yield return new WaitForSeconds(delayBetweenChar);
            outputText.text += character;
        }
        pageEnded = true;
    }

    //Setter for input text
    public void SetInputText(string[] inputText)
    {
        this.inputText = inputText;
    }

    //Method that loads next text
    public void loadNextText()
    {
        if(!pageEnded)
        {
            return;
        }

        if (currentTextIndex >= inputText.Length-1)
        {
            ClosePanel();
            return;
        }

        currentTextIndex++;
        StartCoroutine(textAppear(0, delayBetweenChar, currentTextIndex));
    }

    public void ClosePanel()
    {
        PlayerPrefsController.SetTutorialDone(true);
        TimeManager.VirtualPlay(true);
        Destroy(gameObject);
    }

    
}
