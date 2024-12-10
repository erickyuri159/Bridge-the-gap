using UnityEngine;

public class StartButton : MonoBehaviour
{
    public SoundManager soundManager; // Refer�ncia ao SoundManager
    public GameObject menuPanel; // Refer�ncia ao painel do menu
    public GameObject gamePanel; // Refer�ncia ao painel do jogo

    public void OnStartButtonPressed()
    {
        if (soundManager != null)
        {
            soundManager.PlayGameSound(); // Reproduz o som do jogo
        }
        // Esconde o painel do menu e mostra o painel do jogo
        if (menuPanel != null)
        {
            menuPanel.SetActive(false);
        }
        if (gamePanel != null)
        {
            gamePanel.SetActive(true);
        }
    }
}