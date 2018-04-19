using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerWalls : MonoBehaviour {

    public Sprite dmgSprite;
    public int hp = 4;

    private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Awake () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (gameObject.GetComponent<Enemy>() != null)
            dmgSprite = null;
	}
	public void DamageWall (int loss)
    {
        if(gameObject.GetComponent<Enemy>() != null)
        {
            Enemy enemy = gameObject.GetComponent<Enemy>();
            enemy.DamageEnemy(loss);
        }
        spriteRenderer.sprite = dmgSprite;
        hp -= loss;
        if (hp <= 0)
            gameObject.SetActive(false);
    }

}
