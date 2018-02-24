using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelPerfecrCamera : MonoBehaviour {

	Vector2 position;



	// Use this for initialization
	void Awake () {
		GetComponent<Camera>.orthographicSize = Screen.height / 2;
		position = transform.position;
		transform.position = new Vector2 (position.x - .1f, position.y - .1f, -10);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
