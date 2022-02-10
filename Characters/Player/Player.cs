using UnityEngine;

public class Player : MonoBehaviour, ICharacter
{
    [SerializeField] private GameObject extraLifeOffer;
    [SerializeField] private GameObject gameOverMenu;

    [SerializeField] private Transform playerTransform;

    [SerializeField] private Rigidbody playerRigidbody;

    public void PlayerRespawn()
    {
        PlatformLifeTimeCounter[] platforms = FindObjectsOfType<PlatformLifeTimeCounter>();
        
        float platformLifeTime = 0f;

        int platformSelected = 0;

        for (int i = 0; i < platforms.Length; i++)
        {
            if (platformLifeTime < platforms[i].GetLifeTimeInfo())
            {
                platformLifeTime = platforms[i].GetLifeTimeInfo();
                platformSelected = i;
            }
        }

        Vector3 respawnPosition = platforms[platformSelected].transform.position;
        respawnPosition.y = 5f;

        playerRigidbody.velocity = Vector3.zero;
        playerRigidbody.angularVelocity = Vector3.zero;

        playerTransform.rotation = Quaternion.identity;
        playerTransform.position = respawnPosition;
    }

    public void Death()
    {
        FindObjectOfType<PlayingUI>().HidePlayingUI();

        Time.timeScale = 0f;
        extraLifeOffer.SetActive(true);
    }
}
