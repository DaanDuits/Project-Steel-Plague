using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopButtonBehaviour : MonoBehaviour
{
    [SerializeField] GameObject field;
    bool isEnabled;

    public void OpenCloseShop()
    {
        isEnabled = !isEnabled;
        field.SetActive(isEnabled);
    }
}
