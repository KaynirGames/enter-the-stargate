using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclePatterns; // набор шаблонов с точками спавна объектов

    [SerializeField] private float lastSpawnTime; // задержка между спавнами 
    [SerializeField] private float spawnTimeDecrease; // величина снижения задержки между спавнами
    [SerializeField] private float minSpawnTime; // минимальная задержка между спавнами

    private float spawnCooldown; // счетчик задержки между спавнами

    private void Update()
    {
        if (spawnCooldown <= 0)
        {
            int randomPattern = GetComponent<SpawnRandomizer>().FindRandomIndex();

            Instantiate(obstaclePatterns[randomPattern], transform.position, Quaternion.identity);

            spawnCooldown = lastSpawnTime;

            if (lastSpawnTime > minSpawnTime)
            {
                lastSpawnTime -= spawnTimeDecrease;
            }
        }
        else
        {
            spawnCooldown -= Time.deltaTime;
        }
    }
}
