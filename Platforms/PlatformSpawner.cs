using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private GameObject platformPrefab;
    [SerializeField] private Transform platformTransform;

    public void SpawnNewPlatform()
    {
        Vector3 positionForSpawn = platformTransform.position;
        float distanceBetweenPlatforms = platformTransform.localScale.x;

        switch (Random.Range(0, 4))
        {
            case 0:
                positionForSpawn.x += distanceBetweenPlatforms;
                break;
            case 1:
                positionForSpawn.x -= distanceBetweenPlatforms;
                break;
            case 2:
                positionForSpawn.z += distanceBetweenPlatforms;
                break;
            case 3:
                positionForSpawn.z -= distanceBetweenPlatforms;
                break;
        }

        Instantiate(platformPrefab, positionForSpawn, Quaternion.identity);
    }
}
