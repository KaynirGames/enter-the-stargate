using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Скрипт для уничтожения ненужных объектов

public class JunkDestroyer : MonoBehaviour
{
    [SerializeField] private float destroyTimer;

    void Start()
    {
        Destroy(gameObject, destroyTimer);
    }
}
