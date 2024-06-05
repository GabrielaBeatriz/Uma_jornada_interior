using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    public float moveSpeed = 2f;
    public bool platform1, platform2;
    public bool moveRight = true, moveUp = true;
    public float distanciaX;
    public float distanciaY;
    public float distanciaPercorridaX = 3f;
    public float distanciaPercorridaY = 2f;

    private void Start()
    {
        distanciaX = transform.position.x;
        distanciaY = transform.position.y;
    }


    // Update is called once per frame
    void Update()
    {
        if (platform1)
        {
            if (transform.position.x > distanciaX)
            {
                moveRight = false;
            }
            else if (transform.position.x < distanciaX - distanciaPercorridaX) 
            {
                moveRight = true;
            }

            if (moveRight)
            {
                transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector2.right * -moveSpeed * Time.deltaTime);
            }
        }
        
        if (platform2)
        {
            if (transform.position.y > distanciaY)
            {
                moveUp = false;
            }
            else if (transform.position.y < distanciaY - distanciaPercorridaY)
            {
                moveUp = true;
            }

            if (moveUp)
            {
                transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector2.up * -moveSpeed * Time.deltaTime);
            }
        }
    }
}
