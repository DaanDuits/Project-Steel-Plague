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
        slider.maxValue = 100;
        slider.value = 0;
    }

    private void Update()
    {

        switch (robot.bots)
        {
            case 1:
                if (slider.value == 0)
                {
                    slider.value += 10;
                }
                break;
            case 100:
                if (slider.value <= 10)
                {
                    slider.value += 10;
                }
                break;
            case 250:
                if (slider.value <= 20)
                {
                    slider.value += 10;
                }
                break;
            case 500:
                if (slider.value <= 30)
                {
                    slider.value += 10;
                }
                break;
            case 750:
                if (slider.value <= 40)
                {
                    slider.value += 10;
                }
                break;
            case 1000:
                if (slider.value <= 50)
                {
                    slider.value += 10;
                }
                break;
            case 2500:
                if (slider.value <= 60)
                {
                    slider.value += 10;
                }
                break;
            case 5000:
                if (slider.value <= 70)
                {
                    slider.value += 10;
                }
                break;
            case 7500:
                if (slider.value <= 80)
                {
                    slider.value += 10;
                }
                break;
            case 10000:
                if (slider.value <= 90)
                {
                    slider.value += 10;
                }
                break;
        }
    }
}
