using UnityEngine;

public class EnemyMovementAI : MonoBehaviour
{
    [SerializeField] private Transform enemyTransform;

    private Transform targetTransform;

    private Vector3 targetPosition;

    private float moveSpeed = 1.2f;

    private void Start()
    {
        if (FindObjectOfType<Player>() != null && FindObjectOfType<Player>().TryGetComponent<Transform>(out Transform _playerTransform))
        { 
            targetTransform = _playerTransform;
        }
    }

    private void FixedUpdate()
    {
        if (targetTransform != null)
        {
            targetPosition = targetTransform.position;
            targetPosition.y = enemyTransform.position.y;

            enemyTransform.LookAt(targetPosition);
            enemyTransform.position = Vector3.MoveTowards(enemyTransform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }

    public void GetDamage()
    {
        moveSpeed = 0f;
        Invoke(nameof(SetMoveSpeedValue), 1f);
    }

    private void SetMoveSpeedValue()
    {
        moveSpeed = 1.2f;
    }

}