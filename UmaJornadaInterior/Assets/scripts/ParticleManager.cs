using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public GameObject prefabFumacinha;


    private void OnEnable()
    {
        ParticleObserver.ParticleSpawnEvent += SpawnerParticulas;
    }

    private void OnDisable()
    {
        ParticleObserver.ParticleSpawnEvent -= SpawnerParticulas;

    }


    public void SpawnerParticulas(Vector3 posicao)
    {
        Instantiate(prefabFumacinha, posicao, Quaternion.identity);
    }
}
