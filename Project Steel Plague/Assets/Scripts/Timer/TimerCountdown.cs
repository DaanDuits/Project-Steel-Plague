using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerCountdown : MonoBehaviour
{
    private TextMeshProUGUI timer;

    [SerializeField][Range(10, 599)][Tooltip("Start time in seconds.")] private int startTime;

    private float t;
    private int m;
    private int s;

    private void Start()
    {
        timer = GetComponentInChildren<TextMeshProUGUI>();
        t = startTime + 1;
    }

    private void Update()
    {
        if(t > 0)
        {
            timer.color = (Mathf.FloorToInt(t) > 10) ? Color.white : Color.red;

            m = Mathf.FloorToInt(t / 60);
            s = Mathf.FloorToInt(t % 60);

            timer.text = $"{m}:{s:D2}";
        }
        else
        {
            Debug.Log("Game Over");
            Time.timeScale = 0;
        }

        t -= Time.deltaTime;
    }
}