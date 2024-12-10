using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Som : MonoBehaviour
{
    public AudioClip interactionSound; // Som da intera��o
    private AudioSource audioSource; // Fonte de �udio

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = interactionSound;
    }

    // M�todo para reproduzir o som da intera��o
    public void PlayInteractionSound()
    {
        if (audioSource != null && interactionSound != null)
        {
            audioSource.Play();
        }
    }
}
