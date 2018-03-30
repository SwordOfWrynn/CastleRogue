using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class Player : MovingObject {

    public int WallDamage = 1;
    public int pointsPerCoin = 10;
    public int pointsPerDiamond = 20;
    public int staminaPerPotion = 25;
    public int staminaPerAd = 50;
    public float restartDelay = 1f;
    public Text staminaText;
    public Text scoreText;
    public int horizontal;
    public int vertical;
    public GameObject adCanvas;
    public GameObject menuButton;

    private bool hasWatchedAd = false;
    private Animator animator;
    private int stamina;
    private int score;

	// Use this for initialization
	protected override void Start () {
        staminaText = GameObject.Find("staminaText").GetComponent<Text>();
        scoreText = GameObject.Find("scoreText").GetComponent<Text>();
        adCanvas = GameObject.Find("adCanvas");
        menuButton = GameObject.Find("MenuButton");

        adCanvas.SetActive(false);
        animator = GetComponent<Animator>();
        stamina = GameManager.instance.playerStaminaPoints;
        staminaText.text = ("Stamina: " + stamina);
        score = GameManager.instance.playerScorePoints;
        scoreText.text = ("Score: " + score);
        base.Start();
	}

    private void OnDisable()
    {
        GameManager.instance.playerStaminaPoints = stamina;
        GameManager.instance.playerScorePoints = score;
    }

    // Update is called once per frame
    private void Update () {
        if (!GameManager.instance.playersTurn) return;

        //int horizontal = 0;
        //int vertical = 0;

#if UNITY_STANDALONE || UNITY_WEBPLAYER || UNITY_EDITOR

        horizontal = (int)(Input.GetAxisRaw("Horizontal"));
        vertical = (int)(Input.GetAxisRaw("Vertical"));
        if (horizontal != 0)
        {
            vertical = 0;
        }
        
#else
        //Do nothing
#endif
        if (horizontal != 0 || vertical != 0)
        {
            AttemptMove<InnerWalls>(horizontal, vertical);
            horizontal = 0;
            vertical = 0;
        }
        horizontal = 0;
        vertical = 0;
	}

    public void RightButton()
    {
        horizontal = 1;
    }
    public void UpButton()
    {
        vertical = 1;
    }
    public void LeftButton()
    {
        horizontal = -1;
    }
    public void DownButton()
    {
        vertical = -1;
    }
    protected override void AttemptMove<T>(int xDir, int yDir)
    {
        stamina--;
        staminaText.text = ("Stamina: " + stamina);
        scoreText.text = ("Score: " + score);
        base.AttemptMove<T>(xDir, yDir);
        RaycastHit2D hit;

        CheckIfGameOver();
        GameManager.instance.playersTurn = false;
    }

    protected override void OnCantMove<T>(T component)
    {
        InnerWalls hitWall = component as InnerWalls;
        hitWall.DamageWall(WallDamage);
        animator.SetTrigger("rogueAttack");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Exit")
        {
            Invoke("Restart", restartDelay);
            enabled = false;
        }
        else if (other.tag == "Coin")
        {
            score += pointsPerCoin;
            scoreText.text = ("+" + pointsPerCoin + " Score: " + score);
            other.gameObject.SetActive(false);
        }
        else if (other.tag == "Diamond")
        {
            score += pointsPerDiamond;
            scoreText.text = ("+" + pointsPerDiamond + " Score: " + score);
            other.gameObject.SetActive(false);
        }
        else if (other.tag == "Potion")
        {
            stamina += staminaPerPotion;
            staminaText.text = ("+" + staminaPerPotion + " Stamina: " + stamina);
            other.gameObject.SetActive(false);
        }
    }
    
    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoseStamina (int loss)
    {
        animator.SetTrigger("rogueHit");
        stamina -= loss;
        staminaText.text = ("-" + loss + " Stamina: " + stamina);
        CheckIfGameOver();
    }

    private void CheckIfGameOver()
    {
        if (stamina <= 0)
            if (!hasWatchedAd)
            {
                adCanvas.SetActive(true);
                Time.timeScale = 0;
            }
            else
                GameManager.instance.GameOver();
    }

    //Ad Code

    public void NoToAds()
    {
        Time.timeScale = 1;
        adCanvas.SetActive(false);
        GameManager.instance.GameOver();
    }
    public void ShowDefaultAd()
    {
        if (!Advertisement.IsReady())
        {
            Debug.Log("Ads not ready for default placement");
            return;
        }

        Advertisement.Show();
    }

    public void ShowRewardedAd()
    {
        const string RewardedPlacementId = "rewardedVideo";
        Time.timeScale = 1;
        menuButton.SetActive(false);
        if (!Advertisement.IsReady(RewardedPlacementId))
        {
            Debug.Log(string.Format("Ads not ready for placement '{0}'", RewardedPlacementId));
            return;
        }

        var options = new ShowOptions { resultCallback = HandleShowResult };
        Advertisement.Show(RewardedPlacementId, options);
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
                adCanvas.SetActive(false);
                menuButton.SetActive(true);
                stamina = stamina + staminaPerAd;
                staminaText.text = ("+" + staminaPerAd + " Stamina: " + stamina);
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
