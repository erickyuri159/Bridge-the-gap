using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip menuSound; // Som do painel inicial
    public AudioClip gameSound; // Som do jogo
    private AudioSource audioSource; // Fonte de �udio

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        PlayMenuSound();
    }

    // M�todo para reproduzir o som do painel inicial
    public void PlayMenuSound()
    {
        if (audioSource != null && menuSound != null)
        {
            audioSource.clip = menuSound;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    // M�todo para reproduzir o som do jogo
    public void PlayGameSound()
    {
        if (audioSource != null && gameSound != null)
        {
            audioSource.clip = gameSound;
            audioSource.loop = true;
            audioSource.Play();
        }
    }
}