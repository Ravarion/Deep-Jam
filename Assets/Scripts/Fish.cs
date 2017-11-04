using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour {

    public Sprite[] sprites;

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
            if(direction > 0)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
        }
        sideSwimSpeed = Random.Range(.005f, .05f) * direction;
        SelectSprite();
        StartCoroutine(ChangeDirections());
    }

	void Update ()
    {
        transform.Translate(new Vector3(sideSwimSpeed, upwardsSwimSpeed, 0));
        if(transform.position.x > utility.GetScreenDimensions().right)
        {
            if(sideSwimSpeed > 0)
            {
                ChangeDirections();
            }
        }
        if (transform.position.x < utility.GetScreenDimensions().left)
        {
            if (sideSwimSpeed < 0)
            {
                ChangeDirections();
            }
        }
    }

    private void SelectSprite()
    {
        GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
    }

    IEnumerator ChangeDirections()
    {
        yield return new WaitForSeconds(Random.Range(.3f, 2f));
        direction *= -1;
        sideSwimSpeed = Random.Range(.005f, .05f) * direction;
        if (sideSwimSpeed < 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }
}
