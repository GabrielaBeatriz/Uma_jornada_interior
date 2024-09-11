using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigo2 : MonoBehaviour
{
    
    public GameObject bolaParalisantePrefab; 
    public Transform pontoDeLancamento; 
    public float intervaloEntreLancamentos = 1f; 
    
    private void Start()
    {
        // Começa a lançar bolas paralisantes periodicamente
        InvokeRepeating("LancarBola", 0f, intervaloEntreLancamentos);
    }
    void LancarBola()
    {
        if (bolaParalisantePrefab != null && pontoDeLancamento != null)
        {
            GameObject bola = Instantiate(bolaParalisantePrefab, pontoDeLancamento.position, Quaternion.identity);
            Rigidbody2D rb = bola.GetComponent<Rigidbody2D>();
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player playerScript = collision.gameObject.GetComponent<player>();
            if (playerScript != null)
            {
                playerScript.ApplyParalysis();
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("fogo"))
        {
            Destroy(col.gameObject);
            Destroy(this.gameObject);
        }
    }

}
