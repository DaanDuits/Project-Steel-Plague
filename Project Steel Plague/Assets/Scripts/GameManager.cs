using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private Collider planet;
    [SerializeField] private Collider[] factories;

    private void Awake()
    {
        Time.timeScale = 1;
    }

    private void Update()
    {
        if(Input.GetMouseButtonUp(1))
        {
            menu.SetActive(true);
            planet.enabled = false;

            foreach(Collider c in factories)
            {
                c.enabled = false;
            }

            Time.timeScale = 0;
        }
    }

    public void SetTimeScale(bool time)
    {
        Time.timeScale = time ? 1 : 0;
    }

    public void Restart()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<CameraMovement>().stream.Close();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<CameraMovement>().stream.Close();

        Application.Quit();
    }
}