using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour {

	float minSpeed = 0.005f;
	float maxSpeed = 0.05f;
	float swimSpeed;
	int side;

	// Use this for initialization
	void Start () {
		swimSpeed = Random.Range (minSpeed, maxSpeed);
		side = Random.Range (0, 1);
		if (side == 0)
			transform.position.Set (-11f, 2.3f, 0f);
		else {
			transform.position.Set (11f, 2.3f, 0f);
			transform.Rotate (0f, 180f, 0f);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (side == 0) {
			transform.Translate (new Vector3 (swimSpeed, 0, 0));
			if (transform.position.x >= 11f)
				Destroy (gameObject);
		}
		else {
			transform.Translate (new Vector3 (-swimSpeed, 0, 0));
			if (transform.position.x <= -11f)
				Destroy (gameObject);
		}
	}
}
