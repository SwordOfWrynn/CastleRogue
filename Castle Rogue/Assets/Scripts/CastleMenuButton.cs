using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CastleMenuButton : MonoBehaviour
{

    public GameObject areYouSure;
    public GameObject yes;
    public GameObject no;
    public GameObject greyOut;
    public GameObject gameManager;

    // Use this for initialization
    void Start()
    {
        areYouSure.SetActive(false);
        yes.SetActive(false);
        no.SetActive(false);
        greyOut.SetActive(false);
        gameManager = GameObject.Find("GameManager(Clone)");
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void MenuButton()
    {
        Time.timeScale = 0;
        areYouSure.SetActive(true);
        yes.SetActive(true);
        no.SetActive(true);
        greyOut.SetActive(true);
    }
    public void Yes()
    {
        Time.timeScale = 1;
        Destroy(gameManager);
        SceneManager.LoadScene("MainMenu");
    }
    public void No()
    {
        Time.timeScale = 1;
        areYouSure.SetActive(false);
        yes.SetActive(false);
        no.SetActive(false);
        greyOut.SetActive(false);
    }
}
