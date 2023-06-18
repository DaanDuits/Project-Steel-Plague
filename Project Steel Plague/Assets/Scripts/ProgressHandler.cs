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

    [SerializeField] Slider slider;

    private void Start()
    {
        slider.maxValue = 200;
        winMenu.SetActive(false);
    }

    private void Update()
    {
        slider.value = robot.bots;

        switch (robot.bots)
        {
            case 1:
                NewMilestone();
                break;
            case 50:
                NewMilestone();
                break;
            case 100:
                NewMilestone();
                break;
            case 150:
                NewMilestone();
                break;
            case 200:
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
