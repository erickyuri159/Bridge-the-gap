using UnityEngine;

public class Player1Controller : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public bool canMoveBoxes = false;
    public bool canMove = true; // Nova propriedade para controlar o movimento
    private Rigidbody2D rb;
    private bool isGrounded = false;
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

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                animator.SetTrigger("Jump"); // Chama a animação de pulo
                isGrounded = false; // Define isGrounded como falso após o pulo
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
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("isGrounded", true); // Atualiza o estado de grounded no Animator
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            animator.SetBool("isGrounded", false); // Atualiza o estado de grounded no Animator
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
