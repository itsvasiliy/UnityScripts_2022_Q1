using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingUI : MonoBehaviour
{
    [SerializeField] GameObject joysticks;
 

    public void ShowPlayingUI()
    {
        joysticks.SetActive(true);    
    }

    public void HidePlayingUI()
    {
        joysticks.SetActive(false);
    }
}
