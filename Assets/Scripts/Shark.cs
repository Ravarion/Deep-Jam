using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Shark : MonoBehaviour {

    public AudioClip bite;

    public int maxHealth;
    private int health;

    public GameObject[] healthIcons;
    public Text fishScore;

    public Vector3 desiredPosition;
    public float movementSpeed = 1f;
    public float movementBuffer = .005f;

    private int fishEaten = 0;

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
                StartCoroutine(DamageFlash());
            }
        }
        else if(collision.gameObject.GetComponent<SeaUrchin>())
        {
            --health;
            StartCoroutine(DamageFlash());
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
            Destroy(collision.gameObject);
            transform.GetChild(0).GetComponent<Animator>().SetTrigger("Bite" + Random.Range(1, 5));
            ++fishEaten;
            fishScore.text = fishEaten.ToString();
            GetComponent<AudioSource>().PlayOneShot(bite);

            if (fishEaten%5 == 0 && health < maxHealth)
            {
                ++health;
                UpdateHealthIcons();
            }
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

    IEnumerator DamageFlash()
    {
        for(int i = 0; i < 4; i++)
        {
            if(i%2 == 0)
            {
                Color newColor = Color.red;
                transform.GetChild(0).GetComponent<SpriteRenderer>().color = newColor;
            }
            else
            {
                Color newColor = Color.white;
                transform.GetChild(0).GetComponent<SpriteRenderer>().color = newColor;
            }
            yield return new WaitForSeconds(.3f);
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene("DeathScene");
    }
}
