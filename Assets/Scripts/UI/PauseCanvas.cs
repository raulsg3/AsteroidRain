﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseCanvas : MonoBehaviour
{

    public void ResumeButton()
    {
        GameManager.instance.PauseGame();
    }

}
