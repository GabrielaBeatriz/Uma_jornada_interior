using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Theo : MonoBehaviour
{
    public float Speed;
    public float StoopingDistance;
    private Transform Target;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, Target.position) > StoopingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, Target.position, Speed * Time.deltaTime);
            
            // Verifica a direção do jogador em relação ao Theo
            if (Target.position.x > transform.position.x)
            {
                // O jogador está à direita
                spriteRenderer.flipX = false; // Olhar para a direita
            }
            else
            {
                // O jogador está à esquerda
                spriteRenderer.flipX = true; // Olhar para a esquerda
            }
        }
    }
}