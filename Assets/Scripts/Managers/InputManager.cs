using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{

    #region Singleton
    public static InputManager instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }
    #endregion

    void Update()
    {
        // Check game inputs
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.instance.PauseGame();
        }
    }

}
