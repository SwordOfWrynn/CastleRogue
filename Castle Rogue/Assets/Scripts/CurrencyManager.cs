using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://www.youtube.com/watch?v=cQHF4_YPvsM

public class CurrencyManager : MonoBehaviour {

    public int money;



	// Use this for initialization
	private void Start () {
        DontDestroyOnLoad(gameObject);
        money = 500000;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
