using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alert : MonoBehaviour {

    public bool shouldFlash;
    public float flashLatency;
    public float flashTimer;

	void Update ()
    {
        if (shouldFlash)
        {
            if (flashTimer > 0)
            {
                flashTimer -= Time.deltaTime;
            }
            else
            {
                flashTimer = flashLatency;
                transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = !transform.GetChild(0).GetComponent<SpriteRenderer>().enabled;
            }
        }
	}

    public void SetShouldFlash(bool value)
    {
        shouldFlash = value;
        if (!shouldFlash)
        {
            transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
