using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class WaveController : MonoBehaviour
{
    public GameObject newWavePanel;
    public GameObject winPanel;
    public GameObject unlockedText;
    public GameObject overlayCanvas;

    private Wave currentWave;
    private int maxWave;
    private int currentWaveSize;
    private bool waveEnded = false;
    private List<Wave> waves = new List<Wave>();

    AttackerSpawner[] attackerSpawners;

    private void Start()
    {
        //Level  object will be loaded from a game object that came from the menu and that wasn't destroyed on load

        attackerSpawners = GameObject.FindObjectsOfType<AttackerSpawner>();
        currentWave = waves[0];
        foreach (AttackerSpawner spawner in attackerSpawners)
        {
            spawner.setSpawnDelays(currentWave.getMinSpawnDelay(), currentWave.getMaxSpawnDelay());
        }
    }

    private void Update()
    {
        if (GameObject.FindObjectOfType<Attacker>() == null && waveEnded && !Base.lost)
        {
            waveEnded = false;
            endWave();
        }
    }

    //This method helps add to the current wave size 
    public void addWaveSize(int add)
    {
        currentWaveSize += 1;
        if (currentWaveSize >= currentWave.GetMaxSize())
        {
            foreach (AttackerSpawner spawner in attackerSpawners)
            {
                spawner.controlSpawnCoroutine("stop");
            }
            waveEnded = true;
        }

    }

    //Method that ends wave 
    private void endWave()
    {
        currentWaveSize = 0;

        if (currentWave.GetIndex() + 1 > maxWave)
        {
            WinPanelDisplay();
            return;
        }

        currentWave = waves[currentWave.GetIndex()];
        newWaveDisplay();
        foreach (AttackerSpawner spawner in attackerSpawners)
        {
            spawner.setSpawnDelays(currentWave.getMinSpawnDelay() , currentWave.getMaxSpawnDelay());
            spawner.controlSpawnCoroutine("start");
        }
    }

    //Method that displays to player start of new wave
    private void newWaveDisplay()
    {
        GameObject panel = Instantiate(newWavePanel, overlayCanvas.transform);
        
        bool isFinal = currentWave.GetIndex() == maxWave;
        TextMeshProUGUI upperText = panel.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI lowerText = panel.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();

        if (!isFinal)
        {
            upperText.text = "WAVE";
            lowerText.text = currentWave.GetIndex().ToString();
        }
        else
        {
            upperText.text = "FINAL";
            lowerText.text = "WAVE";
        }
        Destroy(panel, 1.2f);


    }

    //Method that displays win - screen
    private void WinPanelDisplay()
    {
        TimeManager.VirtualPause();
        GameObject panel = Instantiate(winPanel, overlayCanvas.transform);
        if(FindObjectOfType<LevelContainer>().GetLevel().hasUnlocked == true)
        {
            FindObjectOfType<LevelContainer>().GetLevel().hasUnlocked = false;
            Instantiate(unlockedText, panel.transform);
        }
        unlockEntities();
        UnlockNextLevel();
    }

    //Method that unlocks entities
    private void unlockEntities()
    {
        Level level = FindObjectOfType<LevelContainer>().GetLevel();
        UnlockingManager unlockingManager = FindObjectOfType<UnlockingManager>();


        foreach ( string entity in level.defendersUnlocked)
        {
            Debug.Log(entity);
            unlockingManager.SetDefUnlock(entity, true);
        }

        foreach (string entity in level.attackersUnlocked)
        {
            unlockingManager.SetAttackUnlock(entity, true);
        }
    }

    //unlocks the next level
    private void UnlockNextLevel()
    {
        Level currentLevel = GameObject.FindObjectOfType<LevelContainer>().GetLevel();
        if(currentLevel.index == 6) { return; }
        UnlockingManager unlockingManager = GameObject.FindObjectOfType<UnlockingManager>();
        unlockingManager.SetLevelUnlock(currentLevel.index + 1, true);
    }

    //Getter for the current wave
    public Wave getCurrentWave()
    {
        return currentWave;
    }

    //Setter for the waves
    public void SetWaves(List<Wave> waves)
    {
        this.waves = waves;
    }

    //Setter for maximum number of waves
    public void SetMaxWave(int max)
    {
        maxWave = max;
    }

   

    


}
