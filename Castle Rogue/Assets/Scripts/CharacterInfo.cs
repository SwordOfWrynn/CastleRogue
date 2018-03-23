using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInfo : MonoBehaviour {

    public Button purchaseButton;
    public Button selectButton;

    private bool FemmeFatale = false;

	// Use this for initialization
	void Start () {
		if (FemmeFatale == true)
        {
            purchaseButton.gameObject.SetActive(false);
            selectButton.gameObject.SetActive(true);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void Purchase()
    {

    }
    private void Select()
    {
        
    }
}
