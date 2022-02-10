using UnityEngine;

namespace Assets.Scripts.Characters.Player.PlayerMovement
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private FloatingJoystick movementFloatingJoystick;
        [SerializeField] private FloatingJoystick rotationFloatingJoystick;

        [SerializeField] private Transform playerTransform;

        [SerializeField] private float moveSpeed = 5f;

        private Vector3 moveVector3;

        private void PlayerMove()
        {
            moveVector3 = playerTransform.position;

            moveVector3.x += movementFloatingJoystick.Horizontal * moveSpeed * Time.deltaTime;
            moveVector3.z += movementFloatingJoystick.Vertical * moveSpeed * Time.deltaTime;

            playerTransform.position = moveVector3;
        }

        private void PlayerRotation()
        {
            Vector3 direction = Vector3.zero;
            direction.x = rotationFloatingJoystick.Horizontal;
            direction.z = rotationFloatingJoystick.Vertical;

            playerTransform.rotation = Quaternion.LookRotation(direction);
        }

        private void FixedUpdate()
        {
            PlayerMove();

            if (rotationFloatingJoystick.Direction != Vector2.zero)
                PlayerRotation();
        }
    }
}