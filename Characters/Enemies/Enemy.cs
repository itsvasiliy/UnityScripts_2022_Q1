using UnityEngine;

public class Enemy : MonoBehaviour, ICharacter
{

    public void Death()
    {
        Destroy(gameObject);
    }
}