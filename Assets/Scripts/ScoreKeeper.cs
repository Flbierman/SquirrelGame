// Keeps track of the players score by updating the user interface

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
    public static int score; // Keeps track of the score
    public TextMeshProUGUI scoreText; // Display text on the user interface

    void Start()
    {
        score = 0;
        UpdateScoreUI();
    }

    // Updates the score on user interface
    public void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreUI(); // Update score
    }
}