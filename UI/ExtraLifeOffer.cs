using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExtraLifeOffer : MonoBehaviour
{
    [SerializeField] private GameObject gameOverMenu;

    [SerializeField] private CircleTimer circleTimer;

    public void CloseOffer()
    {
        gameOverMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ViewAdsButton()
    {
        Time.timeScale = 1f;
        
        FindObjectOfType<Player>().PlayerRespawn();
        FindObjectOfType<PlayingUI>().ShowPlayingUI();

        circleTimer.ResetTimer();
        gameObject.SetActive(false);
    }
}
