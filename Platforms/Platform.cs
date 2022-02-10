using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private void Start()
    {
        gameObject.TryGetComponent<PlatformLifeTimeCounter>(out PlatformLifeTimeCounter _platformLifeTimeCounter);
        gameObject.TryGetComponent<PlatfromEnemySpawner>(out PlatfromEnemySpawner _platfromEnemySpawner);

        Invoke(nameof(SpawnNewPlatform), _platformLifeTimeCounter.GetLifeTimeInfo() / 2);
        _platfromEnemySpawner.EnemySpawn();
    }

    private void SpawnNewPlatform()
    {
        gameObject.TryGetComponent<PlatformSpawner>(out PlatformSpawner _platformSpawner);
        _platformSpawner.SpawnNewPlatform();
    }
}
