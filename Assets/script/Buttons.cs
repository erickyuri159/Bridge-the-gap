using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void ToStartScreen()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        pauseMenu.isPaused = false;
    }

   

    public void Pause()
    {
        pauseMenu.isPaused = true;
    }

    public void Resume()
    {
        pauseMenu.isPaused = false;
    }
}
