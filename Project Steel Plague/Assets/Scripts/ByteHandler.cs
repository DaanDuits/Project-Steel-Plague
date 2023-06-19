using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ByteHandler : MonoBehaviour
{
    [SerializeField] TMP_Text byteCounter;
    [SerializeField] int bytes;
    public static ByteHandler main;
    public int clickAmount = 1;

    private void Awake()
    {
        main = this;
    }

    private void Update()
    {
        byteCounter.text = bytes.ToString();
    }

    public void AddBytes()
    {
        bytes += clickAmount;
    }
    public void AddBytes(int amount)
    {
        bytes += amount;
    }
    public void RemoveBytes(int amount)
    {
        if (bytes - amount >= 0)
            bytes -= amount;
    }
    public bool CheckPrices(int price)
    {
        if (bytes - price >= 0)
            return true;
        return false;
    }
}
