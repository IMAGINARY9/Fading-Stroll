﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoCache
{
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
