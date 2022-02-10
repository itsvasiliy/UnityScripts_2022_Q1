using UnityEngine;

namespace Assets.Scripts.Guns.RayGun.RayGunShooting
{
    public class RayGunShooting : MonoBehaviour
    {
        [SerializeField] private FloatingJoystick shootingFloatingJoystick;

        [SerializeField] private Transform playerBodyTransform;
        [SerializeField] private Transform gunMuzzleTransform;

        [SerializeField] private Rigidbody bulletPrefab;

        private float bulletSpeed = 50f;
        private float fireRate = 0.2f;

        private bool isShooting = false;
        private void ResetShootingStatus() => isShooting = false;

        private void Update()
        {
            if (shootingFloatingJoystick.Direction != Vector2.zero && !isShooting)
            {
                Rigidbody bulletClone;
                bulletClone = (Rigidbody)Instantiate(bulletPrefab, gunMuzzleTransform.position, playerBodyTransform.rotation);
                bulletClone.velocity = playerBodyTransform.forward * bulletSpeed;

                isShooting = true;
                Invoke(nameof(ResetShootingStatus), fireRate);
            }
        }
    }
}