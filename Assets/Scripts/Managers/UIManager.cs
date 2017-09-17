using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // GUI text fields to be updated
    public Text livesValue;
    public Text timeValue;
    public Text scoreValue;

    #region Singleton
    public static UIManager instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }
    #endregion

    public void UpdateLivesValue(int lives)
    {
        // Lives value is displayed using only one digit
        livesValue.text = lives.ToString();
    }

    public void UpdateTimeValue(int seconds)
    {
        // Time value is displayed (in seconds) using two digits
        string newTimeValue;

        if (seconds < 10)
            newTimeValue = "0" + seconds;
        else
            newTimeValue = seconds.ToString();

        timeValue.text = newTimeValue;
    }

    public void UpdateScoreValue(int score)
    {
        // Score value is displayed (in asteroids) using three digits
        string newScoreValue;

        if (score < 10)
            newScoreValue = "00" + score;
        else if (score < 100)
            newScoreValue = "0" + score;
        else
            newScoreValue = score.ToString();

        scoreValue.text = newScoreValue;
    }

}
