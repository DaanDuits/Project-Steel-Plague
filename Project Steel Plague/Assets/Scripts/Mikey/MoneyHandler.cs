using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyHandler : MonoBehaviour
{
    [SerializeField] private Text botAmountText;
    [SerializeField] private Text byteAmountText;

    private bool routineRunning = true;

    //[SerializeField] private float upgradeDecimal = 1f;
    [SerializeField] private float bits;
    [SerializeField] private float bots;
    [SerializeField] private float botsGive = 1f;
    private void Start()
    {
        StartCoroutine(onCoroutine());
        botsGive = 1;
    }

    private void Update()
    {
        byteAmountText.text = bits.ToString();
        botAmountText.text = bots.ToString();
    }

    public void GetMoney(int receiveMoney)
    {
        bits += receiveMoney;
    }

    public void UseMoney(int giveMoney)
    {
        if (bits > 0 && bits >= giveMoney)
        {
            bits -= giveMoney;
            bots += 1;
        }
        if(bits <= 0 && bits < giveMoney)
        {
            return;
        }
    }

    public void UpgradeBot()
    {
        if (bits > 0 && bits >= 50)
        {
            bits -= 50;
            botsGive *= 2;
        }
        if (bits <= 0 && bits < 50)
        {
            return;
        }
    }

    IEnumerator onCoroutine()
    {
        while (true)
        {
            bits += bots * botsGive;

            yield return new WaitForSeconds(1f);
        }
    }
}