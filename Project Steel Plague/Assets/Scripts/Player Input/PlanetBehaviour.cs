using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetBehaviour : MonoBehaviour, IClickable
{

    public void OnClick()
    {
        ByteHandler.main.AddBytes(1);
    }

    private void OnMouseDown()
    {
        OnClick();
    }
}
