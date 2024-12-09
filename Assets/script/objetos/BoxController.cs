using UnityEngine;

public class MovableObject : MonoBehaviour
{
    private bool isBeingMoved = false;
    private Transform player;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isBeingMoved && player != null)
        {
            rb.MovePosition(player.position);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Player1Controller player1 = collision.gameObject.GetComponent<Player1Controller>();
        Player2Controller player2 = collision.gameObject.GetComponent<Player2Controller>();

        if (player2 != null && player2.canMoveBoxes)
        {
            player = collision.transform;
            isBeingMoved = true;
            rb.mass = 1; // Normal mass when being moved by Player2
        }
        else if (player1 != null)
        {
            rb.mass = 8000; // Very high mass to simulate being immovable by Player1
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform == player)
        {
            isBeingMoved = false;
            player = null;
        }
        else if (collision.gameObject.GetComponent<Player1Controller>() != null)
        {
            rb.mass = 1; // Reset to normal mass when Player1 leaves
        }
    }
}
