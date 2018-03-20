using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour {

    //right character info
    public GameObject characterInfo;
    public Button purchaseOrSelect;
    public Text buttonText;
    public Text characterName;
    public Text characterDescription;
    public GameObject characterImage;
    //left buttons
    public Button thisButton;
    public Sprite newSprite;
    public string newCharacterName;
    public string newCharacterDescription;

    private bool femmeFatale = false;

    // Use this for initialization
    void Start () {
		
	}
    public void SetUp()
    {

    }
    public void OnClick()
    {
        characterName.text = newCharacterName;
        characterDescription.text = newCharacterDescription;
        characterImage.GetComponent<Image>().sprite = newSprite;
    }

    public void SelectOrPurchase()
    {
        if (femmeFatale)
        {

        }
    }

}
