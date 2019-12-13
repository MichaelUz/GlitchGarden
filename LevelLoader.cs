using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader levelLoader;

    [SerializeField] int waitTime = 3;


    int currentSceneIndex;
    private void Awake()
    {
        if (levelLoader == null)
        {
            levelLoader = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        //Set our current scene index and start loading next scene
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            StartCoroutine(LoadWaitForTime(waitTime));
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += UpdateCurrentSceneIndex;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= UpdateCurrentSceneIndex;
    }

    //IEnumerator that loads Scene after certain amount of time
    IEnumerator LoadWaitForTime(float time)
    {
        yield return new WaitForSeconds(time);
        LoadNextScene();
    }

    //Helper methods ------------------------------------------------------------------------------------------------------------------

    //Loads Scene after this one in build settings 
    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    //Loads next scene after delay
    public void LoadSceneDelay(float delay)
    {
        StartCoroutine(LoadWaitForTime(delay));
    }
    //Loads scene base don build index
    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    //Update current scene index
    private void UpdateCurrentSceneIndex(Scene scene , LoadSceneMode mode)
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }


}
