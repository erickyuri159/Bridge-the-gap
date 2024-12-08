using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform player1; // Refer�ncia ao primeiro personagem
    public Transform player2; // Refer�ncia ao segundo personagem
    public float minDistance = 5.0f; // Dist�ncia m�nima entre os personagens para a c�mera ajustar
    public float smoothTime = 0.5f; // Tempo de suaviza��o para o movimento da c�mera

    private Vector3 velocity = Vector3.zero;
    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player1 != null && player2 != null)
        {
            Vector3 midpoint = (player1.position + player2.position) / 2;
            float distance = Vector3.Distance(player1.position, player2.position);

            Vector3 newPosition = midpoint;
            newPosition.z = transform.position.z; // Manter a posi��o Z da c�mera
            transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);

            // Ajustar a posi��o dos jogadores para mant�-los dentro da vis�o da c�mera
            Vector3 player1ViewportPos = cam.WorldToViewportPoint(player1.position);
            Vector3 player2ViewportPos = cam.WorldToViewportPoint(player2.position);

            if (player1ViewportPos.x < 0.1f) player1.position = cam.ViewportToWorldPoint(new Vector3(0.1f, player1ViewportPos.y, player1ViewportPos.z));
            if (player1ViewportPos.x > 0.9f) player1.position = cam.ViewportToWorldPoint(new Vector3(0.9f, player1ViewportPos.y, player1ViewportPos.z));
            if (player1ViewportPos.y < 0.1f) player1.position = cam.ViewportToWorldPoint(new Vector3(player1ViewportPos.x, 0.1f, player1ViewportPos.z));
            if (player1ViewportPos.y > 0.9f) player1.position = cam.ViewportToWorldPoint(new Vector3(player1ViewportPos.x, 0.9f, player1ViewportPos.z));

            if (player2ViewportPos.x < 0.1f) player2.position = cam.ViewportToWorldPoint(new Vector3(0.1f, player2ViewportPos.y, player2ViewportPos.z));
            if (player2ViewportPos.x > 0.9f) player2.position = cam.ViewportToWorldPoint(new Vector3(0.9f, player2ViewportPos.y, player2ViewportPos.z));
            if (player2ViewportPos.y < 0.1f) player2.position = cam.ViewportToWorldPoint(new Vector3(player2ViewportPos.x, 0.1f, player2ViewportPos.z));
            if (player2ViewportPos.y > 0.9f) player2.position = cam.ViewportToWorldPoint(new Vector3(player2ViewportPos.x, 0.9f, player2ViewportPos.z));
        }
    }
}
