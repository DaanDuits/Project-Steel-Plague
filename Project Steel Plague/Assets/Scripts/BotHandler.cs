using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BotHandler : MonoBehaviour
{
    public int bots;
    [SerializeField] TMP_Text botCounter;
    [SerializeField] TMP_Text botGiveCounter;
    [SerializeField] int price;
    //[SerializeField] float priceModifier;
    public int byteModifier;
    public float timeModifier;
    public static BotHandler main;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip clipBuy;

    private bool tutorialText = true;

    private void Start()
    {
        main = this;
        StartCoroutine(AutomateBytes());
    }

    private void Update()
    {
        botCounter.text = bots.ToString();
        botGiveCounter.text = (bots * byteModifier).ToString();
    }

    public void BuyBots(int amount)
    {
        if (ByteHandler.main.CheckPrices(price))
        {
            audioSource.PlayOneShot(clipBuy);
            ByteHandler.main.RemoveBytes(price);
            bots += amount;
            //price += (int)(price * priceModifier);

            if(tutorialText)
            {
                tutorialText = false;
                GameObject.Find("Tutorial").GetComponentInChildren<TextMeshProUGUI>().text = "Robots give you bytes,\nyou can use them to buy other things";
                StartCoroutine(TutorialTimer());
            }
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

    IEnumerator TutorialTimer()
    {
        yield return new WaitForSeconds(5);

        GameObject.Find("Tutorial").GetComponentInChildren<TextMeshProUGUI>().text = "";
    }
}
