using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryHandler : MonoBehaviour
{
    [SerializeField] int factories;
    [SerializeField] int price;
    [SerializeField] Transform factoriesParent;

    public int botModifier;
    public float timeModifier;
    public static FactoryHandler main;

    private void Start()
    {
        main = this;
    }

    public void AddFactory()
    {
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
