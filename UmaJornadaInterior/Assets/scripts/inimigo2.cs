using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigo2 : MonoBehaviour
{
    public GameObject bolaParalisantePrefab; 
    public Transform pontoDeLancamento; 
    public float intervaloEntreLancamentos = 1f; 

    public int vida = 3; // Adiciona a vida do inimigo

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

    public void ReceberDano(int dano) // Método para receber dano
    {
        vida -= dano; // Reduz a vida do inimigo
        if (vida <= 0)
        {
            Morrer();
        }
    }

    void Morrer() // Método chamado quando a vida do inimigo chega a zero
    {
        Destroy(gameObject);
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
        if (col.gameObject.CompareTag("fogo"))
        {
            Destroy(col.gameObject);
            Destroy(this.gameObject);
        }
    }
}
