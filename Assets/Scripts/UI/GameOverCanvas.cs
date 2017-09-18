using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverCanvas : MonoBehaviour
{

    public void PlayAgainButton()
    {
        SceneManager.LoadScene("AsteroidRain");
    }

    public void ExitButton()
    {
        Application.Quit();
    }

}
