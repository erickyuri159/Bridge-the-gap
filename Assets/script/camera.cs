using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform player1; // Referência ao primeiro personagem
    public Transform player2; // Referência ao segundo personagem
    public float minDistance = 5.0f; // Distância mínima entre os personagens para a câmera ajustar
    public float smoothTime = 0.5f; // Tempo de suavização para o movimento da câmera

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
            newPosition.z = transform.position.z; // Manter a posição Z da câmera
            transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);

            // Ajustar a posição dos jogadores para mantê-los dentro da visão da câmera
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
