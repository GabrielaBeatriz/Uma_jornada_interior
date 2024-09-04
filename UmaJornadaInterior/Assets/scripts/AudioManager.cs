using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    
    public static AudioManager instance;
    
    public AudioSource musicSource, sfxSource;

    public AudioClip clipPulo, clipColetavel;

    [SerializeField] private float Volume = 1f;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else 
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        AudioObserver.PlayMusicEvent += TocarMusica;
        AudioObserver.StopMusicEvent += PararMusica;
        AudioObserver.PlaySfxEvent += TocarEfeitoSonoro;
        AudioObserver.OnVolumeChanged += AtualizarVolume;
    }


    private void OnDisable()
    {
        AudioObserver.PlayMusicEvent -= TocarMusica;
        AudioObserver.StopMusicEvent -= PararMusica;
        AudioObserver.PlaySfxEvent -= TocarEfeitoSonoro;
        AudioObserver.OnVolumeChanged -= AtualizarVolume;

    }

    
    void TocarEfeitoSonoro(string NomeDoClip)
    {
        switch (NomeDoClip)
        {
            case "pulo":
                sfxSource.PlayOneShot(clipPulo);
                break;
            case "coletavel":
                sfxSource.PlayOneShot(clipColetavel);
                break;
            default:
                Debug.LogError($"efeito sonoro {NomeDoClip} não encontrado");
                break;
        }
    }

    void AtualizarVolume(float volume)
    {
        this.Volume = volume;
        musicSource.volume = volume;
        sfxSource.volume = volume;
    }

    void TocarMusica()
    {
        musicSource.Play();
    }

    void PararMusica()
    {
        musicSource.Stop();
    }
}
