using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Shark : MonoBehaviour {

    public int maxHealth;
    private int health;

    public GameObject[] healthIcons;

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
            }
        }
        else if(collision.gameObject.GetComponent<SeaUrchin>())
        {
            --health;
            Destroy(collision.gameObject);
        }
        UpdateHealthIcons();
        if (health <= 0)
        {
            GameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Fish>())
        {
            ++health;
            UpdateHealthIcons();
            Destroy(collision.gameObject);
        }
    }

    private void UpdateHealthIcons()
    {
        for(int i = 0; i < maxHealth; i++)
        {
            if(health > i)
            {
                healthIcons[i].GetComponent<Image>().enabled = true;
            }
            else
            {
                healthIcons[i].GetComponent<Image>().enabled = false;
            }
        }
    }

    private void GameOver()
    {
        SceneManager.LoadScene("DeathScene");
    }
}
