using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressHandler : MonoBehaviour
{
    public BotHandler robot;

    [SerializeField] private GameObject winMenu;
    [SerializeField] private Collider planet;
    [SerializeField] private Collider[] factories;
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

        slider.maxValue = 200;
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
            case 50:
                robots[1].SetActive(true);
                humans[1].SetActive(false);
                NewMilestone();
                break;
            case 100:
                robots[2].SetActive(true);
                humans[2].SetActive(false);
                NewMilestone();
                break;
            case 150:
                robots[3].SetActive(true);
                humans[3].SetActive(false);
                NewMilestone();
                break;
            case 200:
                robots[4].SetActive(true);
                humans[4].SetActive(false);
                NewMilestone();
                Debug.Log("Game Over");
                winMenu.SetActive(true);
                planet.enabled = false;

                foreach (Collider c in factories)
                {
                    c.enabled = false;
                }

                Time.timeScale = 0;
                break;
        }
    }

    public void NewMilestone()
    {
        Debug.Log("milestone");
    }
}
