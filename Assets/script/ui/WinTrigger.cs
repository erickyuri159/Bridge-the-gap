using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    public GameObject winPanel; // Referência ao painel de "Você Ganhou!"

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1") || other.CompareTag("Player2"))
        {
            if (winPanel != null)
            {
                winPanel.SetActive(true); // Exibe o painel de "Você Ganhou!"
            }
        }
    }
}
