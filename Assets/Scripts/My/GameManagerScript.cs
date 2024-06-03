using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    SpawnEnemy spawnEnemy;
    List<EnemyBehaviour> listOfAllEnemies;

    [SerializeField] List<Transform> spawnPoints;
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] float initialDelayToSpawnEnemy;
    [SerializeField] float minDelayToSpawnEnemy;
    float currentDelay;

    private void Start()
    {
        listOfAllEnemies = new List<EnemyBehaviour>();
        currentDelay = initialDelayToSpawnEnemy;
        spawnEnemy = new SpawnEnemy(this, spawnPoints, enemyPrefabs);
    }

    private void Update()
    {
        Spawn();
    }

    void Spawn()
    {
        currentDelay -= Time.deltaTime;
        if (currentDelay <= 0)
        {
            currentDelay = initialDelayToSpawnEnemy;
            currentDelay = Mathf.Max(currentDelay, minDelayToSpawnEnemy);
            spawnEnemy.Spawn(listOfAllEnemies);
            initialDelayToSpawnEnemy *= 0.9f;
        }
    }
}
