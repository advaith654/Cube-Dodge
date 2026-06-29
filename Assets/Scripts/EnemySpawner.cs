using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance;

    public GameObject enemyPrefab;

    public int startingEnemies = 2;
    public int maxEnemies = 10;

    public float enemySpeed = 3f;

    private List<EnemyAI> enemies = new List<EnemyAI>();

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < startingEnemies; i++)
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        Vector3 pos = RandomEdgePosition();

        GameObject enemy = Instantiate(enemyPrefab, pos, Quaternion.identity);

        EnemyAI ai = enemy.GetComponent<EnemyAI>();

        ai.speed = enemySpeed;

        enemies.Add(ai);
    }

    Vector3 RandomEdgePosition()
    {
        float size = 23f;

        int edge = Random.Range(0, 4);

        switch (edge)
        {
            case 0:
                return new Vector3(-size, 0.5f, Random.Range(-size, size));

            case 1:
                return new Vector3(size, 0.5f, Random.Range(-size, size));

            case 2:
                return new Vector3(Random.Range(-size, size), 0.5f, size);

            default:
                return new Vector3(Random.Range(-size, size), 0.5f, -size);
        }
    }

    public void IncreaseDifficulty()
    {
        enemySpeed += 0.5f;

        foreach (EnemyAI enemy in enemies)
        {
            enemy.IncreaseSpeed(0.5f);
        }

        if (enemies.Count < maxEnemies)
        {
            SpawnEnemy();
        }

        Debug.Log("Difficulty Increased!");
    }
}