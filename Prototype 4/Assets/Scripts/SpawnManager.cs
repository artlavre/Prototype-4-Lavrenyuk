using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject poweUp;
    private float spawnRange = 9;
    public float enemyCount;
    public int waveNumber = 3;
    void Start()
    {
        SpawnEnemyWave(2);
    }

    void Update()
    {
        int range = Random.Range(0, waveNumber);
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if(enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(range);
            Instantiate(poweUp, GenerateSpawnPoint(), transform.rotation);
        }
    }
    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for(int i = 0; i < enemiesToSpawn; i++)
        Instantiate(enemyPrefab, GenerateSpawnPoint(), enemyPrefab.transform.rotation);
    }

    private Vector3 GenerateSpawnPoint()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }
}
