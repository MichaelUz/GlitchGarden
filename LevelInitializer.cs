using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInitializer : MonoBehaviour
{
    public static LevelInitializer levelInitializer;

    public Level currentLevel;
    public GameObject overlayCanvas;
    public GameObject tutorialPanelPrefab;
    private Defender[] myDefenderTeam;


    private void Awake()
    {
        
        currentLevel = FindObjectOfType<LevelContainer>().GetLevel();

        myDefenderTeam = FindObjectOfType<Defenders>().getMyTeam();

        //Level Initialization--------------------------------
        InitializeWaves();
        InitializeStarCount();
        InitializeAttackers();


    }

    private void Start()
    {
        //Level Initialization
        //PlayerPrefsController.SetTutorialDone(false); 
        InitializeTutorialPanel();
    }


    //Initialize our waves of enemies for this level
    private void InitializeWaves()
    {

        //Initialize our list of waves
        List<Wave> waves = new List<Wave>();
        WaveController waveController = GetComponent<WaveController>();

        int index = 0;
        if(currentLevel == null) { Debug.Log("current level is null"); }
        foreach (Vector2 spawnDelayPair in currentLevel.spawnDelays)
        {
            Wave wave = new Wave(spawnDelayPair.x, spawnDelayPair.y , index +1);
            wave.SetMaxSize(currentLevel.waveSizes[index]);
            waves.Add(wave);
            index++;

        }
        waveController.SetWaves(waves);

        //Initialize maximum amount of waves
        waveController.SetMaxWave(currentLevel.maxWaves);
        
    }

    //Initialize initial star count
    private void InitializeStarCount()
    {
        StarDisplay starDisplay = FindObjectOfType<StarDisplay>();
        starDisplay.SetStars(currentLevel.startingStarCount);
    }

    //Initialize Attackers
    private void InitializeAttackers()
    {
        Attackers attackers = FindObjectOfType<Attackers>();
        attackers.SetAttackTeam(currentLevel.attackerTeam);
        attackers.sort();
    }

    //Initialize tutorial Panel
    private void InitializeTutorialPanel()
    {
        if(PlayerPrefsController.GetTutorialDone())
        {
            TimeManager.VirtualPlay(true);
            return;
        }
        if (currentLevel.hasTutorial)
        {
            GameObject tutorialPanel = Instantiate(tutorialPanelPrefab, overlayCanvas.transform);
            tutorialPanel.GetComponent<TutorialPanelController>().SetInputText(currentLevel.tutorialText);
            return;
        }
        TimeManager.VirtualPlay(true);

    }
}
