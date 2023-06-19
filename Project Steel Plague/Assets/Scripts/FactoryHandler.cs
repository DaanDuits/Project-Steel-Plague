using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class FactoryHandler : MonoBehaviour
{
    [SerializeField] int factories;
    [SerializeField] int price;
    [SerializeField] Transform factoriesParent;
    [SerializeField] private TMP_Text factoryGiveCounter;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip clipBuy;

    public int botModifier;
    public float timeModifier;
    public static FactoryHandler main;

    private void Start()
    {
        main = this;
    }

    private void Update()
    {
        factoryGiveCounter.text = (factories * botModifier).ToString();
    }

    public void AddFactory()
    {
        audioSource.PlayOneShot(clipBuy);

        if (ByteHandler.main.CheckPrices(price) && factories < factoriesParent.childCount)
        {
            ByteHandler.main.RemoveBytes(price);
            factoriesParent.GetChild(factories).gameObject.SetActive(true);
            factories++;
        }
    }

    public IEnumerator automateFactories()
    {
        while (true)
        {
            BotHandler.main.AddBots(factories * botModifier);

            yield return new WaitForSeconds(timeModifier);
        }
    }
}
