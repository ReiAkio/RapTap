using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource bgMusic;
    [SerializeField] private AudioSource rapMusic;
    [SerializeField] private AudioSource sfxSource;

    [SerializeField] private AudioClip[] click_sfx;

    public void PlayBgMusic ()
    {
        bgMusic.Play();
    }

    public void PlayRapMusic ()
    {
        rapMusic.time = bgMusic.time % 16;
        rapMusic.Play(0);
    }

    public void PauseRapMusic ()
    {
        rapMusic.Pause();
    }

    public void PlayClickSFX()
    {
        int n = Random.Range(0, 5);
        sfxSource.PlayOneShot(click_sfx[n], 1f);
    }
}
