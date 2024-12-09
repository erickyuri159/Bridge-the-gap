using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform openPosition; // Posição da porta aberta
    public Transform closedPosition; // Posição da porta fechada
    public float speed = 2f; // Velocidade de movimento da porta
    private bool isOpening = false;

    void Update()
    {
        if (isOpening)
        {
            MoveDoor();
        }
    }

    public void ActivateDoor()
    {
        isOpening = true;
    }

    void MoveDoor()
    {
        transform.position = Vector3.MoveTowards(transform.position, openPosition.position, speed * Time.deltaTime);
        if (transform.position == openPosition.position)
        {
            isOpening = false; // Para a porta ao chegar na posição aberta
        }
    }
}
