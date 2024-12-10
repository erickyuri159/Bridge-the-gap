using UnityEngine;

public class ElevatorButtonIndicator : MonoBehaviour
{
    public float moveDistance = 10f; // Distância que o botão se moverá para cima e para baixo
    public float moveSpeed = 2f; // Velocidade do movimento

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Calcula a nova posição do botão
        float newY = startPosition.y + Mathf.Sin(Time.time * moveSpeed) * moveDistance;
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }
}
