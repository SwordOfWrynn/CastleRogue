using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyDisplay : MonoBehaviour {

    private CurrencyManager currencyManager;
    private Text moneyText;

	// Use this for initialization
	void Start () {
        currencyManager = GameObject.Find("CurrencyManager").GetComponent<CurrencyManager>();
        moneyText = GetComponent<Text>();
        moneyText.text = currencyManager.money.ToString();
	}
	public void RefreshMoney()
    {
        moneyText.text = "Money: " + currencyManager.money.ToString();
    }
}
