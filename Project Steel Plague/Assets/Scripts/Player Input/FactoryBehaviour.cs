using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FactoryBehaviour : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI newFactory;

    private List<TextMeshProUGUI> pool = new List<TextMeshProUGUI>();

    private TextMeshProUGUI GetPoolObject()
    {
        for(int i = 0; i < pool.Count; i++)
        {
            if(!pool[i].gameObject.activeInHierarchy)
            {
                return pool[i];
            }
        }

        TextMeshProUGUI newNewFactory = Instantiate(newFactory, GameObject.Find("Canvas").transform);
        newNewFactory.gameObject.SetActive(false);

        pool.Add(newNewFactory);

        return newNewFactory;
    }

    private void OnMouseDown()
    {
        BotHandler.main.AddBots(1);

        TextMeshProUGUI text = GetPoolObject();

        text.transform.position = Input.mousePosition;
        text.gameObject.SetActive(true);
    }
}
