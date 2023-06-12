using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject menu;

    private void Awake()
    {
        Time.timeScale = 1;
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            menu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void SetTimeScale(bool time)
    {
        Time.timeScale = time ? 1 : 0;
    }

    public void Quit()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<CameraMovement>().stream.Close();

        Application.Quit();
    }
}