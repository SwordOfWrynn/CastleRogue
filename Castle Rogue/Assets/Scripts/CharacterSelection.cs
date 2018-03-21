using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour {

    public int money = 50000;

    //right character info
    public GameObject characterInfo;
    public GameObject selectButton;
    public GameObject purchaseButton;
    public Text purchaseButtonText;
    public Text characterName;
    public Text characterDescription;
    public GameObject characterImage;
    //left buttons
    public int price;
    public Button thisButton;
    public Sprite newSprite;
    public string newCharacterName;
    public string newCharacterDescription;
    public Button[] allButtons;

    private bool rogue = true;
    private bool femmeFatale = false;

    // Use this for initialization
    void Start () {
        selectButton.SetActive(false);
	}
    public void SetUp()
    {

    }
    public void OnClick()
    {
        purchaseButtonText.text = ("Price" + price);
        characterName.text = newCharacterName;
        characterDescription.text = newCharacterDescription;
        characterImage.GetComponent<Image>().sprite = newSprite;
        if (thisButton == allButtons[0])
        {
            if (rogue == true)
            {
                selectButton.SetActive(true);
                purchaseButton.SetActive(false);
            }
        }
        if (thisButton == allButtons[1])
        {
            if (femmeFatale == true)
            {
                selectButton.SetActive(true);
                purchaseButton.SetActive(false);
            }
        }
    }

    public void Purchase()
    {
        if (money >= price)
        {
            money = money - price;
            femmeFatale = true;
        }
    }

}
