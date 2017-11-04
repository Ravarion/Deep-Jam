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
        float scale = Random.Range(0.2f, 0.6f);
        transform.localScale = new Vector3(scale, scale, 1);

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
                DirectionSwitch();
            }
        }
        if (transform.position.x < utility.GetScreenDimensions().left)
        {
            if (sideSwimSpeed < 0)
            {
                DirectionSwitch();
            }
        }
        if(transform.position.y > 10)
        {
            Destroy(gameObject);
        }
    }

    private void SelectSprite()
    {
        GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
    }

    private void DirectionSwitch()
    {
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

    IEnumerator ChangeDirections()
    {
        yield return new WaitForSeconds(Random.Range(.3f, 1f));
        DirectionSwitch();
    }
}
