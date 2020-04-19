using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Выбирает случайный объект с учетом заданных вероятностей спавна
/// </summary>

public class SpawnRandomizer : MonoBehaviour
{
    [SerializeField] private List<int> spawnChancesTable; // список совокупных вероятностей спавна

    public int FindRandomIndex()
    {
        int randomNumber = Random.Range(0, spawnChancesTable.Last());

        // Пример: { 75, 95, 100 }; randomNumber = 80; 
        // 80 < 75 ? Нет 
        // 80 < 95 ? Да => спавним второй объект

        for (int i = 0; i < spawnChancesTable.Count; i++)
        {
            if (randomNumber <= spawnChancesTable[i])
            {
                return i;
            }
        }
        return spawnChancesTable.Count - 1;
    }
}
