using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shark : MonoBehaviour {

    public Vector3 desiredPosition;
    public float movementSpeed = 1f;
    public float movementBuffer = .005f;

    private void Start()
    {
        desiredPosition = transform.position;
    }

    void Update ()
    {
		if(Vector2.Distance(transform.position, desiredPosition) > movementBuffer)
        {
            transform.position = Vector2.MoveTowards(transform.position, desiredPosition, movementSpeed);
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Fish>())
        {
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.GetComponent<Harpoon>())
        {
            if(!collision.gameObject.GetComponent<Harpoon>().desiredLocationMet)
            {
                GameOver();
            }
        }
    }

    private void GameOver()
    {
        SceneManager.LoadScene("DeathScene");
    }
}
