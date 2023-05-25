using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyHandler : MonoBehaviour
{
    [Header("References for the data display text")] 
    [SerializeField] private Text botAmountText;
    [SerializeField] private Text byteAmountText;

    [Header("Float amounts for the bots and bits")]
    [SerializeField] private float bits;
    [SerializeField] private float bots;

    [Header("The amount that multiplies what the robots will give you per second (Starts at 1)")]
    [SerializeField] private float botsGive = 1f;

    private void Start()
    {
        StartCoroutine(onCoroutine());
        botsGive = 1f;
    }

    private void Update()
    {
        //Constantly updates the referenced text elements on the canvas to be equal to the amount of bots and bits
        byteAmountText.text = bits.ToString();
        botAmountText.text = bots.ToString();
    }

    public void GetMoney(int receiveMoney) //When called, will add receiveMoney to bits. This is used currently for the clicking elements
    {
        bits += receiveMoney;
    }

    public void UseMoney(int giveMoney) // uses money on buying the robots, giveMoney is referenced in the Unity Event of a button
    {
        if (bits > 0 && bits >= giveMoney) //if statements used to circumvent purchase of an item when funds are too low
        {
            // Take the amount of money necessary to buy the item in question, and add one of that item
            bits -= giveMoney;
            bots += 1;
        }
        if(bits <= 0 && bits < giveMoney)
        {
            //return if you don't have enough money
            return;
        }
    }

    public void UpgradeBot()
    {
        if (bits > 0 && bits >= 50) //if statements used to circumvent purchase of an item when funds are too low
        {
            bits -= 50;
            botsGive *= 2;
        }
        if (bits <= 0 && bits < 50)
        {
            return;
        }
    }

    IEnumerator onCoroutine() // Coroutine responsible for the robots producing bytes every second
    {
        while (true)
        {
            bits += bots * botsGive; // The amount of bots will be added to bits every second. With it being multiplied by botsGive, which is an upgrade

            yield return new WaitForSeconds(1f);
        }
    }
}