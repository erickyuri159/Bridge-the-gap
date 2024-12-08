using UnityEngine;

public class Bridge : MonoBehaviour
{
    private Rigidbody2D rb;
    private HingeJoint2D hingeJoint;
    public float dropSpeed = 5.0f; // Velocidade com que a ponte cai

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hingeJoint = GetComponent<HingeJoint2D>();
        rb.isKinematic = true; // Inicia a ponte como cinemática (não afetada pela física)
    }

    public void LowerBridge()
    {
        rb.isKinematic = false; // Ativa a física na ponte
        rb.AddTorque(-dropSpeed, ForceMode2D.Impulse); // Aplica um torque para fazer a ponte cair
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            rb.isKinematic = true; // Torna a ponte cinemática novamente quando atinge o chão
        }
    }
}
