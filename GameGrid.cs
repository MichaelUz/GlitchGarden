using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGrid : MonoBehaviour
{
    //A grid that represents our play space:
        // A value of 0 in the grid means there is not a defender on that position in the grid
        // A value of 1 in the grid means there is a defender on that postion in the grid
        // A value of 2 in the grid means there is a defender as well as a Butterfly on that position in the grid
    public int[,] grid = new int[10,6];
    

    //--------------Helper Methods---------------------------------------------

    //This sets the value of a grid element to 1
    public void addDefender(int gridPosX , int gridPosY)
    {
        //When we add the butterfly , update grid to say that they're two defenders in that position
        if(grid[gridPosX,gridPosY] == 1)
        {
            grid[gridPosX, gridPosY] = 2;
            return;
        }

        grid[gridPosX, gridPosY] = 1;
    }

    //This sets the value of a grid elements to 0
    public void removeDefender(int gridPosX , int gridPosY)
    {
        grid[gridPosX, gridPosY] = 0;
    }

    //This method tells us if we can place defender at grid position
    public bool canPlace(int gridPosX , int gridPosY , Defender def)
    {
        //Butterfly can be placed only if there is a a defender on that position
        Debug.Log(def + " || " + grid[gridPosX, gridPosY]);
        if (def.gameObject.GetComponent<Butterfly>() && grid[gridPosX,gridPosY] == 1) { Debug.Log("returning true"); return true; }
        else if (def.gameObject.GetComponent<Butterfly>() && grid[gridPosX,gridPosY] == 0) { return false; }

        //Case for all other defenders
        if(grid[gridPosX,gridPosY] == 0) { return true; }
        else { return false; }
    }


}
