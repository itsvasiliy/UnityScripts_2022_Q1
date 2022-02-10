using UnityEngine;

public class PlatfromEnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;

    [SerializeField] private Transform platformTransform;

    private int enemyQuality = 4;

    private float enemySpawnRange = 5f;
    private float enemySpawnSpeed = 0.25f;

    public float GetEnemySpawnSpeed()
    {
        return enemySpawnSpeed;
    }

    public void EnemySpawn()
    {
        Vector3 enemySpawnPosition = platformTransform.position;

        enemySpawnPosition.x += Random.Range(-enemySpawnRange, enemySpawnRange);
        enemySpawnPosition.z += Random.Range(-enemySpawnRange, enemySpawnRange);

        enemySpawnPosition.y += platformTransform.localScale.y;

        Instantiate(enemyPrefab, enemySpawnPosition, Quaternion.identity);

        enemyQuality--;

        if (enemyQuality > 0)
            Invoke(nameof(EnemySpawn), enemySpawnSpeed);
    }
}