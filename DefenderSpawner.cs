using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    public static Defender defender;

    private StarDisplay starDisplay;
    private GameGrid grid;

    private void Start()
    {
        starDisplay = GameObject.FindObjectOfType<StarDisplay>();
        grid = GameObject.FindObjectOfType<GameGrid>();
    }

    private void OnMouseDown()
    {
        if(!TimeManager.canPlace)
        {
            return;
        }
        Vector2 clickPos = getSquareClicked();
        AttemptToPlace(clickPos);
    }

    //----------------------------------------------------------------Helper methods--------------------------------------------------------

    //Method that attempts to place defender and places if it can
    private void AttemptToPlace(Vector2 coordinates)
    {
        int x = Mathf.RoundToInt(coordinates.x);
        int y = Mathf.RoundToInt(coordinates.y);

        if (defender && starDisplay && starDisplay.getStars() >= defender.getStarCost() && grid.canPlace(x,y,defender))
        {
            SpawnDefender(coordinates);
        }
    }

    //Returns the square we've clicked on in grid coordinates
    private Vector2 getSquareClicked()
    {
        Vector2 clickedPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickedPos);
        Vector2 gridPos = snapToGrid(worldPos);
        return gridPos;
    }

    //Converts raw position to grid position 
    private Vector2 snapToGrid(Vector2 rawPos)
    {
        //Debug.Log(rawPos);
        float x = Mathf.RoundToInt(rawPos.x);
        float y = Mathf.RoundToInt(rawPos.y);
        return new Vector2(x, y);
    }

    //Spawns a given defender 
    private void SpawnDefender(Vector2 coordinates)
    {
        int x = Mathf.RoundToInt(coordinates.x);
        int y = Mathf.RoundToInt(coordinates.y);

        if (defender == null) { return; }
        grid.addDefender(x, y);
        Defender newDefender = Instantiate(defender, coordinates, Quaternion.identity);
        starDisplay.SpendStars(defender.getStarCost());
    }

}
