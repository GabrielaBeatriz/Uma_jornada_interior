using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class AudioObserver
{
    public static event Action<string> PlaySfxEvent;
    public static event Action<float> OnVolumeChanged;

    

    public static event Action PlayMusicEvent;

    public static event Action StopMusicEvent;
    
    

    public static void OnPlaySfxEvent(string obj)
    {
        PlaySfxEvent?.Invoke(obj);
    }

    public static void OnPlayMusicEvent()
    {
        PlayMusicEvent?.Invoke();
    }

    public static void OnStopMusicEvent()
    {
        StopMusicEvent?.Invoke();
    }


    private static void OnOnVolumeChanged(float volume)
    {
        OnVolumeChanged?.Invoke(volume);
    }

    public static void VolumeChanged(float volume)
    {
      
    }
}
