using UnityEngine;

public class Lever : MonoBehaviour
{
    private bool isActivated = false;
    public GameObject bridge; // Refer�ncia para a ponte
    private bool playerInRange = false;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

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
        if (!isActivated)
        {
            isActivated = true;
            animator.SetTrigger("Pull"); // Ativa a anima��o de puxar a alavanca
            bridge.GetComponent<Bridge>().LowerBridge(); // Chama o m�todo para abaixar a ponte
        }
    }
}
