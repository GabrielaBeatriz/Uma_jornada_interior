using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject platformPrefab; // Prefab da plataforma instável
    public float platformSpawnRate = 2f; // Taxa de geração de plataforma
    public float platformSpeed = 2f; // Velocidade inicial das plataformas
    public float platformDestroyTime = 5f; // Tempo até a plataforma ser destruída
    public float platformAcceleration = 1f; // Aceleração das plataformas

    private Transform player; // Referência ao jogador
    private float lastPlatformSpawnTime; // Último tempo de geração de plataforma

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Encontrar o jogador na cena
        lastPlatformSpawnTime = Time.time; // Inicializar o tempo de geração
    }

    private void Update()
    {
        // Verificar se é hora de gerar uma nova plataforma
        if (Time.time - lastPlatformSpawnTime >= platformSpawnRate)
        {
            SpawnPlatform();
            lastPlatformSpawnTime = Time.time; // Atualizar o tempo de geração
        }
    }

    private void SpawnPlatform()
    {
        // Calcular a posição da plataforma perto do inimigo e do jogador
        Vector3 spawnPosition = new Vector3(transform.position.x, (transform.position.y + player.position.y) / 2f, 0f);

        // Instanciar a plataforma
        GameObject platform = Instantiate(platformPrefab, spawnPosition, Quaternion.identity);

        // Calcular a direção do jogador em relação à plataforma
        Vector2 direction = (player.position - platform.transform.position).normalized;

        // Adicionar velocidade à plataforma na direção do jogador
        platform.GetComponent<Rigidbody2D>().velocity = direction * platformSpeed;

        // Destruir a plataforma após um tempo
        Destroy(platform, platformDestroyTime);
    }
}