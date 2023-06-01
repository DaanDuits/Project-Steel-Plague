using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetBehaviour : MonoBehaviour, IClickable
{
    [SerializeField] MoneyHandler moneyHandler;

    public void OnClick()
    {
        moneyHandler.GetMoney(1);
    }

    private void OnMouseDown()
    {
        OnClick();
    }
}
