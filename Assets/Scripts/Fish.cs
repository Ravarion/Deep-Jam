using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour {

    private float swimSpeed;

    void Start()
    {
        swimSpeed = Random.Range(.01f, .05f);
    }

	void Update ()
    {
        transform.Translate(new Vector3(0, swimSpeed, 0));
	}
}
