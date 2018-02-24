using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelPerfectMove : MonoBehaviour {

    Vector2 position;

	// Use this for initialization
	void Update() {
        position.x += 60 * Time.deltaTime;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = new Vector2(Mathf.Round(position.x), Mathf.Round(position.y));
	}
}
