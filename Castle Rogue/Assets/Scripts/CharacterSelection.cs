using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour {

    public int money = 50000;

    //right character info
    public GameObject[] characterInfo;
    public int characterInfoArrayNumber;
    public Transform characterInfoContent;

    // Use this for initialization
    void Start ()
    {
        foreach (Transform child in characterInfoContent.transform)
        {
            Destroy(child.gameObject);
        }
    }
    public void SetUp()
    {

    }
    public void OnClick()
    {
        foreach (Transform child in characterInfoContent.transform)
        {
            Destroy(child.gameObject);
        }
        GameObject toInstantiate = characterInfo[characterInfoArrayNumber];
        GameObject instance = Instantiate(toInstantiate) as GameObject;
        instance.transform.SetParent(characterInfoContent);
    }
}
