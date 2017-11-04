using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shark : MonoBehaviour {

    public int maxHealth;
    private int health;

    public Vector3 desiredPosition;
    public float movementSpeed = 1f;
    public float movementBuffer = .005f;

    private void Start()
    {
        health = maxHealth;
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
        if(collision.gameObject.GetComponent<Harpoon>())
        {
            if(!collision.gameObject.GetComponent<Harpoon>().desiredLocationMet)
            {
                --health;
                if(health <= 0)
                {
                    GameOver();
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Fish>())
        {
            Destroy(collision.gameObject);
        }
    }

    private void GameOver()
    {
        SceneManager.LoadScene("DeathScene");
    }
}
