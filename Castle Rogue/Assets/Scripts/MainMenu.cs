using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class MainMenu : MonoBehaviour {

    public GameObject PlayButton;
    public GameObject MenuDummy;

    private string gameID = "1732470";

    // Use this for initialization
    void Start () {
        MenuDummy.SetActive(false);
        //Advertisement.Initialize(string gameID);
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
        //load 2nd scene in the build settings; I think it's an array
        SceneManager.LoadScene(1);
    }

    public void CharacterSelection()
    {
        SceneManager.LoadScene("CharacterSelection");
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        PlayButton.SetActive(false);
        MenuDummy.SetActive(true);
    }
    public void Credits()
    {
        SceneManager.LoadScene("Testing");
    }
}
