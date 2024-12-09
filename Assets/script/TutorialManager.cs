using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public GameObject tutorialPanel; // Painel do tutorial
    public Text tutorialText; // Texto do tutorial
    public Button skipButton; // Botão de pular
    public float textDisplayTime = 5f; // Tempo para exibir cada texto

    private Queue<string> tutorialMessages; // Fila de mensagens do tutorial
    private bool isTutorialActive = false;

    void Start()
    {
        tutorialPanel.SetActive(false);
        skipButton.onClick.AddListener(SkipTutorial);
        tutorialMessages = new Queue<string>();
    }

    public void StartTutorial(List<string> messages)
    {
        tutorialMessages.Clear();
        foreach (string message in messages)
        {
            tutorialMessages.Enqueue(message);
        }
        tutorialPanel.SetActive(true);
        isTutorialActive = true;
        DisplayNextMessage();
    }

    void DisplayNextMessage()
    {
        if (tutorialMessages.Count == 0)
        {
            EndTutorial();
            return;
        }

        string message = tutorialMessages.Dequeue();
        tutorialText.text = message;
        StartCoroutine(DisplayMessageForTime());
    }

    IEnumerator DisplayMessageForTime()
    {
        yield return new WaitForSeconds(textDisplayTime);
        if (isTutorialActive)
        {
            DisplayNextMessage();
        }
    }

    void SkipTutorial()
    {
        StopAllCoroutines();
        EndTutorial();
    }

    void EndTutorial()
    {
        tutorialPanel.SetActive(false);
        isTutorialActive = false;
    }
}
