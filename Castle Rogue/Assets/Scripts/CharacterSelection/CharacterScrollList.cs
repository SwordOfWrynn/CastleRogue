using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Item
{
    public string itemName;
    public Sprite itemImage;
    public string itemDescription;
    public int price = 1;
}

public class CharacterScrollList : MonoBehaviour {

    public List<Item> itemList;
    public Transform contentPanel;
    public CharacterScrollList otherScrollList;


	// Use this for initialization
	void Start () {
		
	}
	
    private void AddButtons()
    {

    }
}
