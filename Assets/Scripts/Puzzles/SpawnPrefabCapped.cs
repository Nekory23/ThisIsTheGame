using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPrefabCapped : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private int maxSpawnCount = 10;
    private int spawnCount = 0;


    public void Spawn()
    {
        if (spawnCount < maxSpawnCount) {
            Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
            spawnCount++;
        }
    }
}
