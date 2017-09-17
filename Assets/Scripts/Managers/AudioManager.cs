using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // AudioSource component
    private AudioSource managerAudioSource;

    // Background music
    public AudioClip backgroundMusic;

    #region Singleton
    public static AudioManager instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }
    #endregion

    void Start()
    {
        managerAudioSource = this.GetComponent<AudioSource>();
        PlayBackgroundMusic();
    }

    public void PlayBackgroundMusic()
    {
        managerAudioSource.clip = backgroundMusic;
        managerAudioSource.volume = 0.25f;
        managerAudioSource.Play();
    }

    public void StopBackgroundMusic()
    {
        managerAudioSource.Stop();
        managerAudioSource.clip = null;
    }

}
