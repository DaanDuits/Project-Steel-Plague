using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressHandler : MonoBehaviour
{
    public BotHandler robot;

    [SerializeField] Slider slider;

    private void Start()
    {
        slider.maxValue = 10000;
    }

    private void Update()
    {
        slider.value = robot.bots;

        switch (robot.bots)
        {
            case 1:
                NewMilestone();
                break;
            case 100:
                NewMilestone();
                break;
            case 250:
                NewMilestone();
                break;
            case 500:
                NewMilestone();
                break;
            case 750:
                NewMilestone();
                break;
            case 1000:
                NewMilestone();
                break;
            case 2500:
                NewMilestone();
                break;
            case 5000:
                NewMilestone();
                break;
            case 7500:
                NewMilestone();
                break;
            case 10000:
                NewMilestone();
                break;
        }
    }

    public void NewMilestone()
    {
        Debug.Log("milestone");
    }
}
