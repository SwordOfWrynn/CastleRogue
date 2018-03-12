using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MovingObject {

    public int WallDamage = 1;
    public int pointsPerCoin = 10;
    public int pointsPerDiamond = 20;
    public int staminaPerPotion = 25;
    public float restartDelay = 1f;
    public Text staminaText;
    public Text scoreText;
    public int horizontal;
    public int vertical;

    private Animator animator;
    private int stamina;
    private int score;

	// Use this for initialization
	protected override void Start () {
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
            GameManager.instance.GameOver();
    }
}
