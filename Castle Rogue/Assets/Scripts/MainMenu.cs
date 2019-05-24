using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class MainMenu : MonoBehaviour {

    public GameObject PlayButton;
    public GameObject MenuDummy;
    public GameObject infoPanel;

    // Use this for initialization
    void Start () {
        MenuDummy.SetActive(false);
        infoPanel.SetActive(false);
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
        SceneManager.LoadScene("Castle");
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

    public void OpenInfoDisplay()
    {
        infoPanel.SetActive(true);
    }

    public void CloseInfoDisplay()
    {
        infoPanel.SetActive(false);
    }

    public void Credits()
    {
        SceneManager.LoadScene("Testing");
    }
}
