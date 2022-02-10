using UnityEngine;

public static class RepulsiveExplosion
{
    public static void ExplosiveForce(Vector3 explosionPosition, float explosionForce, float explosionRadius, float upwardsModifier)
    {
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, explosionRadius);

        foreach (Collider hit in colliders)
        {
            if (hit.TryGetComponent(out Rigidbody _rigidbody))
                _rigidbody.AddExplosionForce(explosionForce, explosionPosition, explosionRadius, upwardsModifier);
        }
    }

    public static void ExplosiveForce(Collider[] colliders, float explosionForce, Vector3 explosionPosition, float explosionRadius, float upwardsModifier)
    {
        foreach (Collider hit in colliders)
        {
            if (hit.TryGetComponent(out Rigidbody _rigidbody))
                _rigidbody.AddExplosionForce(explosionForce, explosionPosition, explosionRadius, upwardsModifier);
        }
    }
}
