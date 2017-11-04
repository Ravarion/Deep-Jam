using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckOrientation : MonoBehaviour {

	public GameObject deadShark;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (deadShark.transform.position.y <= 0) {	
			if (transform.GetComponent<SpriteRenderer> ().enabled == false)
				transform.GetComponent<SpriteRenderer> ().enabled = true;
			if (Input.deviceOrientation == DeviceOrientation.LandscapeLeft)
				SceneManager.LoadScene ("RevengeGame");
		}
	}
}
