using System;
using System.Collections;
using UnityEngine;

public class PauseMenu : MonoCache
{
    public static bool GameIsPaused { get; private set; }
    [SerializeField] private GameObject pauseMenuUI;
    public override void OnTick()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && UI.IsGame)
        {
            if (GameIsPaused)
                Resume();
            else
                Pause();
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
