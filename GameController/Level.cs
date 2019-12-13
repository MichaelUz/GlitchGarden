using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Level" , menuName = "Level")]
public class Level : ScriptableObject
{
    public int index;
    [TextArea(3, 8)] public string[] tutorialText;
    public Attacker[] attackerTeam;
    public Vector2[] spawnDelays;
    public string[] defendersUnlocked;
    public string[] attackersUnlocked;
    public bool hasTutorial;
    public bool hasUnlocked;
    public int maxWaves;
    public int startingStarCount;
    public int[] waveSizes;
    
}
