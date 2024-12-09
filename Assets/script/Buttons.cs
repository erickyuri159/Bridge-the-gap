using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    public Button startButton; // Bot�o "Iniciar"
    public TutorialManager tutorialManager; // Refer�ncia ao TutorialManager

    void Start()
    {
        startButton.onClick.AddListener(OnStartButtonClicked);
        FreezeGame(); // Congela o jogo no in�cio
    }

    void OnStartButtonClicked()
    {
        tutorialManager.ShowTutorial();
        UnfreezeGame(); // Descongela o jogo quando o bot�o "Iniciar" � clicado
    }

    void FreezeGame()
    {
        Time.timeScale = 0f; // Congela o jogo
    }

    void UnfreezeGame()
    {
        Time.timeScale = 1f; // Descongela o jogo
    }

    public void Pause()
    {
        pauseMenu.isPaused = true;
        FreezeGame(); // Congela o jogo quando pausado
    }

    public void Resume()
    {
        pauseMenu.isPaused = false;
        UnfreezeGame(); // Descongela o jogo quando retomado
    }
}
