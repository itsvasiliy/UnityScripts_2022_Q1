using UnityEngine;
using UnityEngine.UI;

public class PlatformLifeTimeCounter : MonoBehaviour
{
    [SerializeField] Text lifeTimeCountText;

    private float timeRemaining = 15f;

    private bool isTimeRunning = true;

    private void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        lifeTimeCountText.text = seconds.ToString();
    }
    
    public float GetLifeTimeInfo()
    {
        return timeRemaining;
    }

    private void Update()
    {
        if (isTimeRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0f;
                isTimeRunning = false;
                Destroy(gameObject);
            }
        }
    }
}
