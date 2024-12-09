using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    public List<string> tutorialMessages; // Mensagens do tutorial

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1") || other.CompareTag("Player2"))
        {
            TutorialManager tutorialManager = FindObjectOfType<TutorialManager>();
            if (tutorialManager != null)
            {
                tutorialManager.StartTutorial(tutorialMessages);
            }
        }
    }
}


