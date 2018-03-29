using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class CharacterInfo : MonoBehaviour {

    public Button purchaseButton;
    public Button selectButton;
    public int characterInfoArrayNumber;
    public int price = 0;
    public CurrencyManager currencyManager;
    public bool[] isBought;

    private int money;
    private bool FemmeFatale = false;

	// Use this for initialization
	void Start () {
        selectButton.gameObject.SetActive(false);
        isBought = new bool[characterInfoArrayNumber + 1];
        GameObject currencyManagerObject = GameObject.Find("CurrencyManager");
        currencyManager = currencyManagerObject.GetComponent<CurrencyManager>();
        money = currencyManager.money;
        Debug.Log("Money = " + money);
        Debug.Log("Array Number = " + characterInfoArrayNumber);
		if (isBought[characterInfoArrayNumber] == true)
        {
            purchaseButton.gameObject.SetActive(false);
            selectButton.gameObject.SetActive(true);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Purchase()
    {
        Debug.Log("Here");
        money = currencyManager.money;
        if (price <= money)
        {
            isBought[characterInfoArrayNumber] = true;
            purchaseButton.gameObject.SetActive(false);
            selectButton.gameObject.SetActive(true);
            money = money - price;
            currencyManager.money = money;
        }
    }
    public void Select()
    {

        //saving the selection
        Debug.Log("foo");
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/SelectedCharacter.dat", FileMode.OpenOrCreate);
        SelectInfo myInfo = new SelectInfo();
        myInfo.character = characterInfoArrayNumber;
        bf.Serialize(file, myInfo);
        file.Close();
    }
}
