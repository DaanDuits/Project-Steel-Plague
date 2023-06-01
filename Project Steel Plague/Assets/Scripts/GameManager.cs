using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<CameraMovement>().stream.Close();

        Application.Quit();
    }
}