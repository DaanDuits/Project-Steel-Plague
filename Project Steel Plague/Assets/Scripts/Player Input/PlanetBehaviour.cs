using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System.Linq;
using UnityEngine.Audio;

public class PlanetBehaviour : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI newByte;
    [SerializeField] private AudioSource planet;
    [SerializeField] private AudioClip clickPlanetSound;

    private List<TextMeshProUGUI> pool = new List<TextMeshProUGUI>();
    public bool tutorialText = true;

    private TextMeshProUGUI GetPoolObject()
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (!pool[i].gameObject.activeInHierarchy)
            {
                return pool[i];
            }
        }

        TextMeshProUGUI newNewByte = Instantiate(newByte, GameObject.Find("Canvas").transform);
        newNewByte.gameObject.SetActive(false);

        pool.Add(newNewByte);

        return newNewByte;
    }

    private void OnMouseDown()
    {
        planet.PlayOneShot(clickPlanetSound);

        ByteHandler.main.AddBytes();

        TextMeshProUGUI text = GetPoolObject();
        text.text = $"+{ByteHandler.main.clickAmount}";

        text.transform.position = Input.mousePosition;
        text.gameObject.SetActive(true);

        if(tutorialText)
        {
            tutorialText = false;
            GameObject.Find("Tutorial").GetComponent<TextMeshProUGUI>().text = "If you have 5 bytes,\nyou can buy a robot";
        }
    }
}
