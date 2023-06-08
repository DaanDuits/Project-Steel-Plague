using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopButtonBehaviour : MonoBehaviour
{
    [SerializeField] Transform arrow;
    [SerializeField] GameObject field;
    bool isEnabled;

    public void OpenCloseShop()
    {
        isEnabled = !isEnabled;
        arrow.localScale = new Vector3(1, -arrow.localScale.y, 1);
        field.SetActive(isEnabled);
    }
}
