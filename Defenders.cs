using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defenders : MonoBehaviour
{
    [SerializeField] private Defender[] myTeam;

    //Set size of my Team;
    public void setTeamSize(int newSize)
    {
        Defender[] hold = new Defender[myTeam.Length];
        myTeam.CopyTo(hold,0);
        myTeam = new Defender[newSize];
        hold.CopyTo(myTeam, 0);
    }

    //Get myTeam
    public Defender[] getMyTeam() { return myTeam; }

    //Setter for my Team
    public void SetDefenderTeam(Defender[] defenderTeam) { this.myTeam = defenderTeam; }

    //Add a defender to our team at a specific index
    public void addDefender(int index , Defender def)
    {
        myTeam[index] = def;
    }
}
