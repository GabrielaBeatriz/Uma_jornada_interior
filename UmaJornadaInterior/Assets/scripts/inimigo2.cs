using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigo2 : MonoBehaviour
{
    
    public GameObject bolaParalisantePrefab; // Prefab da bola paralisante
    public Transform pontoDeLancamento; // Ponto de onde a bola será lançada
    public float intervaloEntreLancamentos = 1f; // Intervalo entre lançamentos
    
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
            if (rb != null)
            {
                rb.velocity = new Vector2(-5f, 0f); // Defina a velocidade e direção conforme necessário
            }
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
