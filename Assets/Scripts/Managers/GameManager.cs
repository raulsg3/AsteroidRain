using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Game score
    private int score = 0;
    public int Score
    {
        get { return score; }
    }

    // Game over
    private bool gameOver = false;
    public bool GameOver
    {
        get { return gameOver; }
    }

    #region Singleton
    public static GameManager instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }
    #endregion

    /**
     * Increase the game score.
     */
    public void IncreaseScore(int points = 1)
    {
        score += points;
    }

    /**
     * Game finished.
     */
    private void EndGame()
    {
        gameOver = true;
    }
}
