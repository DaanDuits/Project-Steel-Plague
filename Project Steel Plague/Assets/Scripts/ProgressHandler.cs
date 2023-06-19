using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressHandler : MonoBehaviour
{
    public BotHandler robot;

    [SerializeField] private GameObject winMenu;
    [SerializeField] private Collider planet;
    [SerializeField] private Collider factory1;
    [SerializeField] private Collider factory2;
    [SerializeField] private Collider factory3;
    [SerializeField] private Collider factory4;
    [SerializeField] private Collider factory5;
    [SerializeField] private GameObject[] humans;
    [SerializeField] private GameObject[] robots;

    [SerializeField] Slider slider;

    private void Start()
    {
        robots[0].SetActive(false);
        robots[1].SetActive(false);
        robots[2].SetActive(false);
        robots[3].SetActive(false);
        robots[4].SetActive(false);

        humans[0].SetActive(true);
        humans[1].SetActive(true);
        humans[2].SetActive(true);
        humans[3].SetActive(true);
        humans[4].SetActive(true);

        slider.maxValue = 500;
        winMenu.SetActive(false);
    }

    private void Update()
    {
        slider.value = robot.bots;

        switch (robot.bots)
        {
            case 1:
                robots[0].SetActive(true);
                humans[0].SetActive(false);
                NewMilestone();
                break;
            case 100:
                robots[1].SetActive(true);
                humans[1].SetActive(false);
                NewMilestone();
                break;
            case 200:
                robots[2].SetActive(true);
                humans[2].SetActive(false);
                NewMilestone();
                break;
            case 350:
                robots[3].SetActive(true);
                humans[3].SetActive(false);
                NewMilestone();
                break;
            case >= 500:
                robots[4].SetActive(true);
                humans[4].SetActive(false);
                NewMilestone();
                winMenu.SetActive(true);
                planet.enabled = false;
                factory1.enabled = false;
                factory2.enabled = false;
                factory3.enabled = false;
                factory4.enabled = false;
                factory5.enabled = false;

                Time.timeScale = 0;
                break;
        }
    }

    public void NewMilestone()
    {
        Debug.Log("milestone");
    }
}
