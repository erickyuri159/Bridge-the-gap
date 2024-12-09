using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public GameObject tutorialPanel; // Painel do tutorial
    public Text tutorialText; // Texto do tutorial
    public Button skipButton; // Bot�o de pular
    public float textDisplayTime = 4f; // Tempo para exibir cada texto

    private Queue<string> tutorialMessages; // Fila de mensagens do tutorial
    private bool isTutorialActive = false;
    private bool hasReadTutorial = false; // Vari�vel para rastrear se o tutorial j� foi lido

    void Start()
    {
        tutorialPanel.SetActive(false);
        skipButton.gameObject.SetActive(hasReadTutorial); // Mostra o bot�o "Pular" se o tutorial j� foi lido
        skipButton.onClick.AddListener(SkipTutorial);
        tutorialMessages = new Queue<string>();
    }

    public void ShowTutorial()
    {
        List<string> initialMessages = new List<string>
        {
            "Bem-vindo ao jogo! voc� ter� controle com os dois personagens",
            "Use as setas para mover seu personagem, com a letra L mudara o personagem.",
            "Pressione a barra de espa�o para pular com o personagem cego. O cadeirante n�o tem pulo",
            "cada personagem tem suas vantagens, o cadeirante te ajudara a empurar coisas pessadas",
            "E seu amigo cego ele ajudara abrir caminho pelas ruas. Boa sorte e divirta-se!"
        };
        StartTutorial(initialMessages);
        hasReadTutorial = true; // Marca que o tutorial foi lido ap�s a primeira exibi��o
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
        FreezePlayers();
        DisplayNextMessage();

        if (hasReadTutorial)
        {
            skipButton.gameObject.SetActive(true); // Mostra o bot�o "Pular" se o tutorial j� foi lido
        }
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
        UnfreezePlayers();
        hasReadTutorial = true; // Marca que o tutorial foi lido
        skipButton.gameObject.SetActive(true); // Mostra o bot�o "Pular" ap�s a primeira leitura
    }

    void FreezePlayers()
    {
        Player2Controller[] player2Controllers = FindObjectsOfType<Player2Controller>();
        foreach (Player2Controller player in player2Controllers)
        {
            player.canMove = false;
        }

        Player1Controller[] player1Controllers = FindObjectsOfType<Player1Controller>();
        foreach (Player1Controller player in player1Controllers)
        {
            player.canMove = false;
        }
    }

    void UnfreezePlayers()
    {
        Player2Controller[] player2Controllers = FindObjectsOfType<Player2Controller>();
        foreach (Player2Controller player in player2Controllers)
        {
            player.canMove = true;
        }

        Player1Controller[] player1Controllers = FindObjectsOfType<Player1Controller>();
        foreach (Player1Controller player in player1Controllers)
        {
            player.canMove = true;
        }
    }
}
