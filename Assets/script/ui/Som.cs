using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Som : MonoBehaviour
{
    public AudioClip interactionSound; // Som da interação
    private AudioSource audioSource; // Fonte de áudio

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = interactionSound;
    }

    // Método para reproduzir o som da interação
    public void PlayInteractionSound()
    {
        if (audioSource != null && interactionSound != null)
        {
            audioSource.Play();
        }
    }
}
