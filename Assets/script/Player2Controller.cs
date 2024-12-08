using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    public bool canMoveBoxes = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Caixa"))
        {
            // Adicione lógica para empurrar objetos aqui, se necessário
        }
    }
}
