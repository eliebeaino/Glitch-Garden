using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesDisplay : MonoBehaviour
{
    public int lives = 50;
    Text livesText;

    private void Start()
    {
        livesText = GetComponent<Text>();
        livesText.text = lives.ToString();
    }

    public void MinusOneLife()
    {
        lives--;
        livesText.text = lives.ToString();
        if (lives == 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        FindObjectOfType<LevelController>().HandleLooseCondition();
    }
}
