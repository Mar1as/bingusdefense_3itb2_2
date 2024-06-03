using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy
{
    GameManagerScript gameManager;

    List<Transform> spawnPoints;
    List<GameObject> enemyPrefabs;

    public SpawnEnemy(GameManagerScript gameManager, List<Transform> spawnPoints, List<GameObject> enemyPrefabs)
    {
        this.gameManager = gameManager;
        this.spawnPoints = spawnPoints;
        this.enemyPrefabs = enemyPrefabs;
    }

    public void Spawn(List<EnemyBehaviour> listOfEnemies)
    {
        Transform curSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];
        GameObject curEnemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];
        GameObject enemy = GameObject.Instantiate(curEnemyPrefab, curSpawnPoint.position, Quaternion.identity);
        EnemyBehaviour enemyBehaviour = enemy.GetComponent<EnemyBehaviour>();
        listOfEnemies.Add(enemyBehaviour);
    }
}
