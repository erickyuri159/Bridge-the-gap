using UnityEngine;

public class Lever2 : MonoBehaviour
{
    private bool playerInRange = false;
    public Elevator elevator; // Refer�ncia para o elevador

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            ActivateLever();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Player1Controller player1 = other.GetComponent<Player1Controller>();

        // Verifica se o personagem cego entrou na �rea da alavanca
        if (player1 != null)
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Verifica se o personagem cego saiu da �rea da alavanca
        if (other.GetComponent<Player1Controller>() != null)
        {
            playerInRange = false;
        }
    }

    void ActivateLever()
    {
        elevator.ActivateElevator(); // Ativa o elevador
    }
}
