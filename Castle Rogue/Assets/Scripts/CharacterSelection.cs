using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour {

    //base right
    public GameObject characterInfo;
    public Button purchaseOrSelect;
    public Text buttonText;
    public Text characterName;
    public Text characterDescription;
    public Image characterImage;

    //left buttons
    public Sprite newSprite;
    public Text newCharacterName;
    public Text newCharacterDescription;

    // Use this for initialization
    void Start () {
		
	}
    public void SetUp()
    {

    }
    public void OnClick()
    {
        characterName = newCharacterName;
        characterDescription = newCharacterDescription;

    }
}
