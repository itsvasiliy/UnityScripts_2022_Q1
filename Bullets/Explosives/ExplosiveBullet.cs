using UnityEngine;

namespace Assets.Scripts.Bullets.Explosives.ExplosiveBullet
{
    public class ExplosiveBullet : MonoBehaviour
    {
        [SerializeField] private Transform bulletTransform;

        [SerializeField] private Rigidbody bulletRigidbody;

        [SerializeField] private float explosionForce;
        [SerializeField] private float explosionRadius;
        [SerializeField] private float upwardsModifier;
        [SerializeField] private float lifeTime;

        private void Awake() => Invoke(nameof(Destruction), lifeTime);

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<EnemyMovementAI>(out EnemyMovementAI _enemyMovementAI))
                _enemyMovementAI.GetDamage();

            RepulsiveExplosion.ExplosiveForce(bulletTransform.position, explosionForce, explosionRadius, upwardsModifier);
            Destruction();
        }

        private void Destruction()
        {
            Destroy(gameObject);
        }
    }

}