using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fogo : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("inimigo")) // Verifica se colidiu com o inimigo
        {
            Debug.Log("Colidiu com o inimigo!"); // Adicione esta linha para depuração
            inimigo2 inimigoScript = other.GetComponent<inimigo2>();
            if (inimigoScript != null)
            {
                inimigoScript.ReceberDano(1); // Causa 1 ponto de dano ao inimigo
                Debug.Log("Dano causado ao inimigo. Vida restante: " + inimigoScript.vida);
            }
            Destroy(gameObject); // Destrói o projétil após a colisão
        }
    }
}

