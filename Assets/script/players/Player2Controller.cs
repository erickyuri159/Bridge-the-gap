using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    public bool canMoveBoxes = true;
    public bool canMove = true; // Nova propriedade para controlar o movimento
    private Animator animator; // Referência ao componente Animator
    private bool facingRight = true; // Variável para rastrear a direção do personagem

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); // Inicializa o Animator
    }

    void Update()
    {
        if (canMove)
        {
            float moveInput = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

            // Atualiza o parâmetro de movimento no Animator
            animator.SetFloat("Speed", Mathf.Abs(moveInput));

            // Verifica a direção do movimento e vira o personagem
            if (moveInput > 0 && !facingRight)
            {
                Flip();
            }
            else if (moveInput < 0 && facingRight)
            {
                Flip();
            }
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y); // Para o movimento
            animator.SetFloat("Speed", 0); // Define a animação de idle
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Caixa"))
        {
            // Adicione lógica para empurrar objetos aqui, se necessário
            animator.SetBool("isPushing", true); // Define a animação de empurrar
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Caixa"))
        {
            animator.SetBool("isPushing", false); // Define a animação de idle
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
