using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;
    GameObject defenderParent;
    const string DEFENDER_PARENT_NAME = "Defenders";

    private void Start()
    {
        createDefenderParent();
    }

    private void createDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if (!defenderParent)
        {
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }

    private void OnMouseDown()      // on mouse down inside collider
    {
        AttemptToPlaceDefenderAt(GetSquareClicked());
    }
    public void SetSelectedDefender (Defender defenderToSelect)
    {
        defender = defenderToSelect;
    }

    private void AttemptToPlaceDefenderAt(Vector2 gridPos)
    {
        var starDisplay = FindObjectOfType<StarDisplay>();
        if (defender != null)
        {
            int defenderCost = defender.GetStarCost();
            if (starDisplay.HaveEnoughStars(defenderCost))
            {
                SpawnDefender(gridPos);
                starDisplay.SpendingStars(defenderCost);
            }
        }
    }

    private Vector2 GetSquareClicked()       // get location of mouse
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 gridPos = SnapToGrid(worldPos);
        return gridPos;
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)     // locking location to grid
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }

    private void SpawnDefender(Vector2 roundedPos)        // spawn on location of mouse
    {
        Defender newDefender = Instantiate(defender, roundedPos, transform.rotation, defenderParent.transform);
    }
}
