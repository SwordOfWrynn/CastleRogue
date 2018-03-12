using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class GameManager : MonoBehaviour {

    public float levelStartDelay = 2f;
    public float turnDelay = .2f;
    public static GameManager instance = null;
    public BoardManager boardScript;
    public int playerStaminaPoints = 100;
    public GameObject adsCanvas;



    [HideInInspector] public int playerScorePoints = 0;
    [HideInInspector] public bool playersTurn = true;
    [HideInInspector] public GameObject MainMenuLossButton;

    private Text levelText;
    private GameObject levelImage;
    private List<Enemy> enemies;
    private bool enemiesMoving;
    private bool doingSetup;
    
    public int level = 1;
    
	void Awake () {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy (gameObject);

        DontDestroyOnLoad(gameObject);

        enemies = new List<Enemy>();

        boardScript = GetComponent<BoardManager>();
        //InitGame();
	}

    //This is called each time a scene is loaded.
    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        //Add one to our level number.
        level++;
        Debug.Log("Level " + level);
        //Call InitGame to initialize our level.
        InitGame();
    }
    void OnEnable()
    {
        //Tell our ‘OnLevelFinishedLoading’ function to start listening for a scene change event as soon as this script is enabled.
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }
    void OnDisable()
    {
        //Tell our ‘OnLevelFinishedLoading’ function to stop listening for a scene change event as soon as this script is disabled.
        //Remember to always have an unsubscription for every delegate you subscribe to!
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
}

void InitGame () {
        doingSetup = true;
        MainMenuLossButton = GameObject.Find("MainMenuLossButton");
        MainMenuLossButton.SetActive(false);
        levelImage = GameObject.Find("levelImage");
        levelText = GameObject.Find("levelText").GetComponent<Text>();
        levelText.text = ("Room " + level);
        levelImage.SetActive(true);
        enemies.Clear();
        boardScript.SetupScene(level);
        Invoke("HideLevelImage", levelStartDelay);
	}

    private void HideLevelImage()
    {
        levelImage.SetActive(false);
        doingSetup = false;
    }

    public void GameOver()
    {
        levelText.text = ("You robbed " + level + " rooms before \n you had to make your escape");
        levelImage.SetActive(true);
        MainMenuLossButton.SetActive(true);
        enabled = false;
    }
    private void Update()
    {
        if (playersTurn || enemiesMoving || doingSetup)
            return;
        StartCoroutine(MoveEnemies());
    }
    public void AddEnemyToList(Enemy script)
    {
        enemies.Add(script);
    }


    IEnumerator MoveEnemies()
    {
        enemiesMoving = true;
        yield return new WaitForSeconds(turnDelay);
        if (enemies.Count == 0)
        {
            yield return new WaitForSeconds(turnDelay);
        }
        for (int i = 0; i < enemies.Count; i++)
        {
            enemies[i].MoveEnemy();
            yield return new WaitForSeconds(0.3f);
        }
        playersTurn = true;
        enemiesMoving = false;
    }

    public void MenuButton()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("MainMenu");
    }


    public void ShowRewardedAd()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show("rewardedVideo", options);
        }
    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");
                //
                // YOUR CODE TO REWARD THE GAMER
                // Give coins etc.
                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                break;
        }
    }
}
