using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Game over
    private bool gameOver = false;
    public bool GameOver
    {
        get { return gameOver; }
        set { gameOver = value; }
    }

    #region Singleton
    public static GameManager instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }
    #endregion

	void Start ()
    {
	}
	
	void Update ()
    {
	}
}
