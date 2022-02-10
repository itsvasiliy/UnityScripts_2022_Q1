using UnityEngine;

public class ExplosionTrigger : MonoBehaviour
{
    [SerializeField] private Transform objectTransform;

    [SerializeField] private float explosionForce;
    [SerializeField] private float explosionRadius;
    [SerializeField] private float upwardsModifier;
    [SerializeField] private float checkTime;

    private bool isPlayerBeenClose = false;

    private void Start() => Invoke(nameof(IsTargetCloseCheck), checkTime);

    private void IsTargetCloseCheck()
    {
        bool isPlayerDetected = false;
        float AdditionalTime = 0f;

        Collider[] colliders = Physics.OverlapSphere(objectTransform.position, explosionRadius);

        foreach (Collider hit in colliders)
        {
            if (hit.TryGetComponent<Player>(out Player _player))
            {
                isPlayerDetected = true;

                if (isPlayerBeenClose)
                {
                    RepulsiveExplosion.ExplosiveForce(colliders, explosionForce, objectTransform.position, explosionRadius, upwardsModifier);
                    Destroy(gameObject);
                }
                else
                {
                    isPlayerBeenClose = true;
                    AdditionalTime = 1f;
                }
            }
        }

        if (isPlayerBeenClose && !isPlayerDetected)
            isPlayerBeenClose = false;
        
        Invoke(nameof(IsTargetCloseCheck), checkTime + AdditionalTime);
    }
}