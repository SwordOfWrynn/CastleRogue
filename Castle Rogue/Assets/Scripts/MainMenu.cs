using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject PlayButton;
    public GameObject MenuDummy;

	// Use this for initialization
	void Start () {
        MenuDummy.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Testing()
    {
        SceneManager.LoadScene("Testing");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void Castle()
    {
        //load top scene in the build settings; I think it's an array
        SceneManager.LoadScene(0);
    }
    public void StartGame()
    {
        Time.timeScale = 1;
        PlayButton.SetActive(false);
        MenuDummy.SetActive(true);
    }
    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
}
