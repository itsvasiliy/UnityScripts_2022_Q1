using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleTimer : MonoBehaviour
{
    [SerializeField] private Image circleImage;

    [SerializeField] private Text timeCounterText;

    [SerializeField] private float waitTime = 5f;
    [SerializeField] private float timeRemaining = 5f;

    private bool isTimeRunning = true;

    public void ResetTimer()
    {
        circleImage.fillAmount = 1f;
        timeRemaining = waitTime;
        isTimeRunning = true; 
    }

    private void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1f;
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeCounterText.text = seconds.ToString();
    }

    private void Update()
    {
        if (isTimeRunning)
        {
            if (timeRemaining > 0)
            {
                circleImage.fillAmount -= 1f / waitTime * Time.unscaledDeltaTime;

                timeRemaining -= Time.unscaledDeltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0f;
                isTimeRunning = false;

                FindObjectOfType<ExtraLifeOffer>().CloseOffer();
            }
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            ResetTimer();   
        }
    }
}
