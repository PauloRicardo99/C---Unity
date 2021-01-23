using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public GameManager gameManager;

    public AudioSource audioSource;
    public AudioClip clickDown;
    public AudioClip clickUp;
    public AudioClip toggle;

    public void PlayClickDownSound()
    {
        audioSource.clip = clickDown;
        audioSource.Play();
    }
    public void PlayClickUpSound()
    {
        audioSource.clip = clickUp;
        audioSource.Play();
    }
    public void toggleSound()
    {
        audioSource.clip = toggle;
        audioSource.Play();
    }
}
