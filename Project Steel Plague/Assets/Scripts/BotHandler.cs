using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BotHandler : MonoBehaviour
{
    public int bots;
    [SerializeField] TMP_Text botCounter;
    [SerializeField] int price;
    //[SerializeField] float priceModifier;
    [SerializeField] int byteModifier, timeModifier;
    public static BotHandler main;

    private void Start()
    {
        main = this;
        StartCoroutine(AutomateBytes());
    }

    private void Update()
    {
        botCounter.text = bots.ToString();
    }

    public void BuyBots(int amount)
    {
        if (ByteHandler.main.CheckPrices(price))
        {
            ByteHandler.main.RemoveBytes(price);
            bots += amount;
            //price += (int)(price * priceModifier);
        }
    }

    public void AddBots(int amount)
    {
        bots += amount;
    }

    IEnumerator AutomateBytes()
    {
        while (true)
        {
            ByteHandler.main.AddBytes(bots * byteModifier);

            yield return new WaitForSeconds(timeModifier);
        }
    }
}
