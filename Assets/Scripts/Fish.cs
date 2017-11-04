using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour {

    private float upwardsSwimSpeed;
    private float sideSwimSpeed;
    private int direction;

    private Utility utility;

    void Start()
    {
        utility = FindObjectOfType<Utility>();
        upwardsSwimSpeed = Random.Range(.01f, .05f);
        while(direction == 0)
        {
            direction = Random.Range(-1, 1);
        }
        sideSwimSpeed = Random.Range(.1f, .4f) * direction;
    }

	void Update ()
    {
        transform.Translate(new Vector3(sideSwimSpeed, upwardsSwimSpeed, 0));
        if(transform.position.x > utility.GetScreenDimensions().right)
        {
            if(direction > 0)
            {
                direction *= -1;
            }
        }
        if (transform.position.x < utility.GetScreenDimensions().left)
        {
            if (direction < 0)
            {
                direction *= -1;
            }
        }
    }

    IEnumerator ChangeDirections()
    {
        yield return new WaitForSeconds(Random.Range(.3f, 2f));
        direction *= -1;
        sideSwimSpeed = Random.Range(0f, .1f) * direction;
    }
}
