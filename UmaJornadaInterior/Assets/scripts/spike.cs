using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class spike : MonoBehaviour
{
    public Vector2 intervalo;
    private Animator anim;

    public void Awake()
    {
        anim = GetComponent<Animator>();
        anim.enabled = false;
    }

    IEnumerator Start()
    {
        yield return new WaitForSeconds(Random.Range(0, 2));
        //anim.enabled = true;
    }
    
}
