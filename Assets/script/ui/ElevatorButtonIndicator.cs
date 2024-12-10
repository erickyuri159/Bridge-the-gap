using UnityEngine;

public class ElevatorButtonIndicator : MonoBehaviour
{
    public float moveDistance = 10f; // Dist�ncia que o bot�o se mover� para cima e para baixo
    public float moveSpeed = 2f; // Velocidade do movimento

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Calcula a nova posi��o do bot�o
        float newY = startPosition.y + Mathf.Sin(Time.time * moveSpeed) * moveDistance;
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }
}
