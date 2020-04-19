using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacles; // набор объектов для спавна
    
    private void Start()
    {
        int obstacleIndex = GetComponent<SpawnRandomizer>().FindRandomIndex();

        Instantiate(obstacles[obstacleIndex], transform.position, Quaternion.identity);
    }
}
