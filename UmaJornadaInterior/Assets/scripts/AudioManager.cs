using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;
    
    public AudioSource musicSource, sfxSource;

    public AudioClip clipPulo, clipColetavel;
    
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
    }


    private void OnDisable()
    {
        AudioObserver.PlayMusicEvent -= TocarMusica;
        AudioObserver.StopMusicEvent -= PararMusica;
        AudioObserver.PlaySfxEvent -= TocarEfeitoSonoro;
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
            case "coletavel1":
                sfxSource.PlayOneShot(clipColetavel);
                break;
            case "coletavel2":
                sfxSource.PlayOneShot(clipColetavel);
                break;
            case "coletavel3":
                sfxSource.PlayOneShot(clipColetavel);
                break;
            default:
                Debug.LogError($"efeito sonoro {NomeDoClip} não encontrado");
                break;
        }
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
