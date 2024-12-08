using UnityEngine;

public class CharacterSwitcher : MonoBehaviour
{
    public GameObject[] characters; // Array de personagens
    private int currentCharacterIndex = 0;

    void Start()
    {
        // Ativar o personagem inicial e desativar os outros
        for (int i = 0; i < characters.Length; i++)
        {
            characters[i].SetActive(i == currentCharacterIndex);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) // Pressione Tab para trocar de personagem
        {
            SwitchCharacter();
        }
    }

    void SwitchCharacter()
    {
        // Obter a posição e rotação do personagem atual
        Vector3 currentPosition = characters[currentCharacterIndex].transform.position;
        Quaternion currentRotation = characters[currentCharacterIndex].transform.rotation;

        // Desativar o personagem atual
        characters[currentCharacterIndex].SetActive(false);

        // Atualizar o índice do personagem atual
        currentCharacterIndex = (currentCharacterIndex + 1) % characters.Length;

        // Mover o novo personagem para a posição atual
        characters[currentCharacterIndex].transform.position = currentPosition;
        characters[currentCharacterIndex].transform.rotation = currentRotation;

        // Ativar o novo personagem
        characters[currentCharacterIndex].SetActive(true);
    }
}
