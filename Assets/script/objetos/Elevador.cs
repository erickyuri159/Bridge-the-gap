using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public Transform topPosition; // Posição do topo do elevador
    public Transform bottomPosition; // Posição do fundo do elevador
    public float speed = 2f; // Velocidade de movimento do elevador

    private bool movingUp = false;
    private bool activated = false;

    void Update()
    {
        if (activated)
        {
            MoveElevator();
        }
    }

    public void ActivateElevator()
    {
        if (activated)
        {
            activated = false; // Para o elevador se já estiver ativado
        }
        else
        {
            activated = true; // Ativa o elevador se estiver desativado
            movingUp = !movingUp; // Alterna a direção do movimento
        }
    }

    void MoveElevator()
    {
        if (movingUp)
        {
            transform.position = Vector3.MoveTowards(transform.position, topPosition.position, speed * Time.deltaTime);
            if (transform.position == topPosition.position)
            {
                activated = false; // Para o elevador ao chegar no topo
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, bottomPosition.position, speed * Time.deltaTime);
            if (transform.position == bottomPosition.position)
            {
                activated = false; // Para o elevador ao chegar no fundo
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player2"))
        {
            // Ação quando o Player2 entra no elevador (se necessário)
        }
    }
}
