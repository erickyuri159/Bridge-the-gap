using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    public List<string> tutorialMessages; // Mensagens do tutorial
    private bool hasBeenRead = false; // Flag para verificar se o tutorial já foi lido

    void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.CompareTag("Player1") || other.CompareTag("Player2")) && !hasBeenRead)
        {
            TutorialManager tutorialManager = FindObjectOfType<TutorialManager>();
            if (tutorialManager != null)
            {
                tutorialManager.StartTutorial(tutorialMessages);
                hasBeenRead = true; // Marca o tutorial como lido
            }
        }
    }
}