using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UiObserver 
{
    public static event Action<int> AtualizarVidaEvent;


    public static void OnAtualizarVidaEvent(int obj)
    {
        AtualizarVidaEvent?.Invoke(obj);
    }
}
