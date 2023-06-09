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
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip clipBuy;

    int[] clickPrices = new int[]{
        20, 500, 2000
    };
    int[] botPrices = new int[]{
        2000, 5000, 7500, 10000
    };
    int[] factoryPrices = new int[]{
        5000, 8000, 12000, 180000
    };

    private void Start()
    {
        clickText.text = "" + clickPrices[clickIndex];
        botText.text = "" + botPrices[botIndex];
        factoryText.text = "" + factoryPrices[factoryIndex];
    }

    public void UpgradeClick()
    {
        if (ByteHandler.main.CheckPrices(clickPrices[clickIndex]))
        {
            audioSource.PlayOneShot(clipBuy);
            ByteHandler.main.clickAmount++;
            ByteHandler.main.RemoveBytes(clickPrices[clickIndex]);
            clickIndex++;

            if (clickIndex < clickPrices.Length)
                clickText.text = "" + clickPrices[clickIndex];
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
            audioSource.PlayOneShot(clipBuy);
            if (botIndex == 0 || botIndex == 2)
                BotHandler.main.timeModifier /= 2;
            else if (botIndex == 1 || botIndex == 3)
                BotHandler.main.byteModifier++;
            ByteHandler.main.RemoveBytes(botPrices[botIndex]);
            botIndex++;

            if (botIndex < botPrices.Length)
                botText.text = "" + botPrices[botIndex];
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
            audioSource.PlayOneShot(clipBuy);
            if (factoryIndex == 0)
                StartCoroutine(FactoryHandler.main.automateFactories());
            else if (factoryIndex == 1 || factoryIndex == 3)
                FactoryHandler.main.timeModifier /= 2;
            else if (factoryIndex == 2 || factoryIndex == 4)
                FactoryHandler.main.botModifier++;
            ByteHandler.main.RemoveBytes(factoryPrices[factoryIndex]);
            factoryIndex++;

            if (factoryIndex < factoryPrices.Length)
                factoryText.text = "" + factoryPrices[factoryIndex];
            else
            {
                factoryText.text = "Complete";
                factoryText.color = Color.green;
            }
        }
    }
}
