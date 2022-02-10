using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<ICharacter>(out ICharacter _character))
        {
            _character.Death();
        }
    }
}