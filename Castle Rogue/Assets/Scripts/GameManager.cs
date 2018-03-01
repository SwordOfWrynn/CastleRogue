using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;



    public BoardManager boardScript;

    public int level = 3;
    
	void Awake () {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy (gameObject);

        DontDestroyOnLoad(gameObject);



        boardScript = GetComponent<BoardManager>();
        InitGame();
	}
	
	void InitGame () {
        boardScript.SetupScene(level);
	}
}
