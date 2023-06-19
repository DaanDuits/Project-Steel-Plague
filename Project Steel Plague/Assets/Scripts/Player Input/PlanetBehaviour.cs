using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System.Linq;

public class PlanetBehaviour : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI newByte;

    private List<TextMeshProUGUI> pool = new List<TextMeshProUGUI>();

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
        ByteHandler.main.AddBytes();

        TextMeshProUGUI text = GetPoolObject();
        text.text = $"+{ByteHandler.main.clickAmount}";

        text.transform.position = Input.mousePosition;
        text.gameObject.SetActive(true);
    }
}
