using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MovingObject {

    public int WallDamage = 1;
    public int pointsPerFood = 10;
    public int pointsPerSoda = 20;
    public float restartDelay = 1f;
    public Text foodText;

    private Animator animator;
    private int food;

	// Use this for initialization
	protected override void Start () {
        animator = GetComponent<Animator>();
        food = GameManager.instance.playerFoodPoints;
        foodText.text = ("Score" + food);
        base.Start();
	}

    private void OnDisable()
    {
        GameManager.instance.playerFoodPoints = food;
    }

    // Update is called once per frame
    private void Update () {
        if (!GameManager.instance.playersTurn) return;

        int horizontal = 0;
        int vertical = 0;
        horizontal = (int)(Input.GetAxisRaw("Horizontal"));
        vertical = (int)(Input.GetAxisRaw("Vertical"));
        if (horizontal != 0)
        {
            vertical = 0;
        }
    

        if (horizontal != 0 || vertical != 0)
        {
            AttemptMove<InnerWalls>(horizontal, vertical);
        }
	}

 protected override void AttemptMove<T>(int xDir, int yDir)
    {
        food--;
        foodText.text = ("Score" + food);
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
        else if (other.tag == "Food")
        {
            food += pointsPerFood;
            other.gameObject.SetActive(false);
        }
        else if (other.tag == "Soda")
        {
            food += pointsPerSoda;
            other.gameObject.SetActive(false);
        }
    }
    
    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoseFood (int loss)
    {
        animator.SetTrigger("rogueHit");
        food -= loss;
        CheckIfGameOver();
    }

    private void CheckIfGameOver()
    {
        if (food <= 0)
            GameManager.instance.GameOver();
    }
}
