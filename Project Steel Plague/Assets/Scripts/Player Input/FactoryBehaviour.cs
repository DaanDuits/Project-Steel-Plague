using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryBehaviour : MonoBehaviour
{
    private void OnMouseDown()
    {
        BotHandler.main.AddBots(1);
    }
}
