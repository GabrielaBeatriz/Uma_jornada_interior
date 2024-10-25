using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


   public class BolaParalisante : MonoBehaviour
   {
           private Rigidbody2D rb;
           public float tempoDeVida = 3f; // Tempo em segundos antes da bola se destruir
       
           void Start()
           {
               rb = GetComponent<Rigidbody2D>();
               if (rb != null)
               {
                   rb.velocity = new Vector2(-5f, 0f); 
               }
       
               // Inicia a contagem para destruir a bola após o tempo de vida
               Destroy(gameObject, tempoDeVida);
           }
       
           private void OnTriggerEnter2D(Collider2D other)
           {
               if (other.CompareTag("Player"))
               {
                   other.GetComponent<player>().Damage(1);
                   Destroy(gameObject);
               }
           }
       
           void Update()
           {
               // Você pode adicionar funcionalidades aqui, se necessário
           }
       }
