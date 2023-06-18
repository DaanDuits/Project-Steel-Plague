using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeHandler : MonoBehaviour
{
    int clickIndex;
    int botIndex;
    int factoryIndex;

    [SerializeField]
    TMP_Text clickText, botText, factoryText;

    int[] clickPrices = new int[]{
        20, 500, 2000
    };
    int[] botPrices = new int[]{
        2000, 7500, 20000, 50000
    };
    int[] factoryPrices = new int[]{
        7000, 20000, 60000, 150000
    };

    private void Start()
    {
        clickText.text = "Clicks: " + clickPrices[clickIndex];
        botText.text = "Bots: " + botPrices[botIndex];
        factoryText.text = "Factories: " + factoryPrices[factoryIndex];
    }

    public void UpgradeClick()
    {
        if (ByteHandler.main.CheckPrices(clickPrices[clickIndex]))
        {
            ByteHandler.main.clickAmount++;
            ByteHandler.main.RemoveBytes(clickPrices[clickIndex]);
            clickIndex++;

            if (clickIndex < clickPrices.Length)
                clickText.text = "Clicks: " + clickPrices[clickIndex];
            else
            {
                clickText.text = "Complete";
                clickText.color = Color.green;
            }
        }
    }
    public void UpgradeBots()
    {
        if (ByteHandler.main.CheckPrices(botPrices[botIndex]))
        {

            if (botIndex == 0 || botIndex == 2)
                BotHandler.main.timeModifier /= 2;
            else if (botIndex == 1 || botIndex == 3)
                BotHandler.main.byteModifier++;
            ByteHandler.main.RemoveBytes(botPrices[botIndex]);
            botIndex++;

            if (botIndex < botPrices.Length)
                botText.text = "Bots: " + botPrices[botIndex];
            else
            {
                botText.text = "Complete";
                botText.color = Color.green;
            }
        }
    }
    public void UpgradeFactories()
    {
        if (ByteHandler.main.CheckPrices(factoryPrices[factoryIndex]))
        {
            if (factoryIndex == 0)
                StartCoroutine(FactoryHandler.main.automateFactories());
            else if (factoryIndex == 1 || factoryIndex == 3)
                FactoryHandler.main.timeModifier /= 2;
            else if (factoryIndex == 2 || factoryIndex == 4)
                FactoryHandler.main.botModifier++;
            ByteHandler.main.RemoveBytes(factoryPrices[factoryIndex]);
            factoryIndex++;

            if (factoryIndex < factoryPrices.Length)
                factoryText.text = "Factories: " + factoryPrices[factoryIndex];
            else
            {
                factoryText.text = "Complete";
                factoryText.color = Color.green;
            }
        }
    }
}
