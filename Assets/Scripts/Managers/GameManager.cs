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

    // Game time
    public float gameTimeSeconds = 60f;
    public float TimeSeconds
    {
        get { return gameTimeSeconds; }
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

    // Game paused
    private bool gamePaused = false;
    public bool GamePaused
    {
        get { return gamePaused; }
    }

    #region Singleton
    public static GameManager instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }
    #endregion

    void Start()
    {
        // GUI initial values
        UIManager.instance.UpdateLivesValue(gameLives);
        UIManager.instance.UpdateScoreValue(score);
        UIManager.instance.UpdateTimeValue(Mathf.FloorToInt(gameTimeSeconds));

        // Time running
        Time.timeScale = 1f;
    }

    void Update()
    {
        // Time remaining
        UpdateTime(Time.deltaTime);
    }

    /**
     * Decrease the remaining time.
     */
    private void UpdateTime(float deltaTime)
    {
        gameTimeSeconds -= deltaTime;

        if (gameTimeSeconds <= 0f)
            EndGame();
        else
            UIManager.instance.UpdateTimeValue(Mathf.FloorToInt(gameTimeSeconds));
    }

    /**
     * Decrease the number of lives remaining.
     */
    public void LoseLife()
    {
        gameLives--;
        UIManager.instance.UpdateLivesValue(gameLives);
        UIManager.instance.LoseLife();

        if (gameLives == 0)
            EndGame();
    }

    /**
     * Increase the game score.
     */
    public void IncreaseScore(int points = 1)
    {
        score += points;
        UIManager.instance.UpdateScoreValue(score);
    }

    /**
     * Game paused.
     */
    public void PauseGame()
    {
        gamePaused = !gamePaused;
        Time.timeScale = (GamePaused || GameOver) ? 0f : 1f;

        if (!GameOver)
            UIManager.instance.PauseGame(GamePaused);
    }

    /**
     * Game finished.
     */
    private void EndGame()
    {
        gameOver = true;
        PauseGame();

        UIManager.instance.EndGame(Score);
        AudioManager.instance.StopBackgroundMusic();
    }
}
