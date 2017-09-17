using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Game lives
    public int gameLives = 5;
    public int Lives
    {
        get { return gameLives; }
    }

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
     * Decrease the number of lives remaining.
     */
    public void LoseLife()
    {
        gameLives--;

        if (gameLives == 0)
            EndGame();
    }

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
        AudioManager.instance.StopBackgroundMusic();
    }
}
