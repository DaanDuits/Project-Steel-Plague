using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryBehaviour : MonoBehaviour, IClickable
{

    public void OnClick()
    {
        BotHandler.main.AddBots(1);
    }
    private void OnMouseDown()
    {
        OnClick();
    }
}
