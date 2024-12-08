using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject player1; // Referência ao primeiro personagem (cego)
    public GameObject player2; // Referência ao segundo personagem (cadeirante)
    private GameObject activePlayer; // Referência ao personagem ativo

    void Start()
    {
        activePlayer = player1; // Inicialmente, o cego é o personagem ativo
        SetActivePlayer(activePlayer);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L)) // Alterna entre os personagens ao pressionar a tecla L
        {
            TogglePlayer();
        }
    }

    void TogglePlayer() // Alterna entre os personagens
    {
        if (activePlayer == player1)
        {
            activePlayer = player2;
        }
        else
        {
            activePlayer = player1;
        }
        SetActivePlayer(activePlayer);
    }

    void SetActivePlayer(GameObject player) // Define o personagem ativo
    {
        if (player1 != null && player2 != null)
        {
            player1.GetComponent<Player1Controller>().enabled = (player == player1);
            player2.GetComponent<Player2Controller>().enabled = (player == player2);
        }
    }
}