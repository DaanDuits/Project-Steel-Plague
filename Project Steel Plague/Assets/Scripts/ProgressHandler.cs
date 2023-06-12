using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressHandler : MonoBehaviour
{
    public BotHandler robot;
    public Transform progressPanel;

    [SerializeField] private GameObject topBar;
    [SerializeField] private GameObject bottomBar;

    private void Start()
    {

        topBar.SetActive(false);
        bottomBar.SetActive(false);

        RectTransform panelRectTransform = progressPanel.GetComponent<RectTransform>();

        panelRectTransform.sizeDelta = new Vector2 (800, 0);
    }

    private void Update()
    {
        MilestoneStatus();
    }

    public void MilestoneStatus()
    {
        RectTransform panelRectTransform = progressPanel.GetComponent<RectTransform>();

        if (robot.bots >= 1 && robot.bots <= 99)
        {
            panelRectTransform.sizeDelta = new Vector2(50, 10);
            bottomBar.SetActive(true);
        }
        else if (robot.bots >= 100 && robot.bots <= 499)
        {
            panelRectTransform.sizeDelta = new Vector2(50, 30);
        }
        else if (robot.bots >= 500 && robot.bots <= 999)
        {
            panelRectTransform.sizeDelta = new Vector2(50, 50);
        }
        else if (robot.bots >= 1000 && robot.bots <= 4999)
        {
            panelRectTransform.sizeDelta = new Vector2(50, 75);
        }
        else if (robot.bots >= 5000 && robot.bots <= 9999)
        {
            panelRectTransform.sizeDelta = new Vector2(50, 100);
        }
        else if (robot.bots >= 10000 && robot.bots <= 49999)
        {
            panelRectTransform.sizeDelta = new Vector2(50, 150);
        }
        else if (robot.bots >= 50000 && robot.bots <= 99999)
        {
            panelRectTransform.sizeDelta = new Vector2(50, 200);
        }
        else if (robot.bots >= 100000)
        {
            panelRectTransform.sizeDelta = new Vector2(50, 230);
            topBar.SetActive(true);
        }
    }
}
