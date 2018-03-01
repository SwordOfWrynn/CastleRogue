using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MovingObject {

    public int playerDamage;

    private Animator animator;
    private Transform target;
    private bool skipMove;

	// Use this for initialization
	protected override void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
