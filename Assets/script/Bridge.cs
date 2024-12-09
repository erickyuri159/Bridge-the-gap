using UnityEngine;
using UnityEngine.Tilemaps;

public class Bridge : MonoBehaviour
{
    private Rigidbody2D rb;
    public HingeJoint2D hingeJoint;
    public float dropSpeed = 5.0f; // Velocidade com que a ponte cai
    public Vector2 finalPosition; // Posi��o final da ponte

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hingeJoint = GetComponent<HingeJoint2D>();
        rb.isKinematic = true; // Inicia a ponte como cinem�tica (n�o afetada pela f�sica)
    }

    public void LowerBridge()
    {
        rb.isKinematic = false; // Ativa a f�sica na ponte
        rb.AddTorque(-dropSpeed, ForceMode2D.Impulse); // Aplica um torque para fazer a ponte cair
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<TilemapCollider2D>() != null)
        {
            rb.isKinematic = true; // Torna a ponte cinem�tica novamente quando atinge o Tilemap Collider 2D
            rb.velocity = Vector2.zero; // Para o movimento da ponte
            rb.angularVelocity = 0f; // Para a rota��o da ponte
            transform.position = finalPosition; // Define a posi��o final da ponte
            transform.rotation = Quaternion.identity; // Reseta a rota��o da ponte
        }
    }
}


