using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enable : MonoBehaviour {

    public GameObject toEnable;
    public float timer;
	
	// Update is called once per frame
	void Update () {
		if(timer > 0)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                toEnable.SetActive(true);
            }
        }
	}

    public void EnableObject()
    {
        toEnable.SetActive(true);
    }
}
