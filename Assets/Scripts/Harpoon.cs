using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harpoon : MonoBehaviour {

    public GameObject harpoonAlertPrefab;

    public GameObject harpoonAlert;

    public float alertTimer;
    private bool attacking = true;

    public Vector3 desiredLocation;
    public float attackingSpeed;
    public float floatingSpeed;
    public bool desiredLocationMet = false;

    private GameObject shark;

	void Start ()
    {
        Instantiate(harpoonAlertPrefab);
        shark = FindObjectOfType<Shark>().gameObject;
        transform.position = new Vector3(0,5);
	}
	
	void Update ()
    {
        if (!attacking)
        {
            alertTimer -= Time.deltaTime;
            AlertPlayer();
            if (alertTimer <= 0)
            {
                attacking = true;
                TurnOffAlert();
                transform.position = new Vector3(harpoonAlert.transform.position.x, transform.position.y);
                desiredLocation = new Vector3(harpoonAlert.transform.position.x, 0);
            }
        }
        else
        {
            if (Vector2.Distance(transform.position, desiredLocation) < attackingSpeed)
            {
                desiredLocationMet = true;
            }
            if (!desiredLocationMet)
            {
                transform.position = Vector3.MoveTowards(transform.position, desiredLocation, attackingSpeed);
            }
            else
            {
                if (transform.position.y < 10)
                {
                    transform.Translate(0, floatingSpeed, 0);
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        }
	}

    void AlertPlayer()
    {
        harpoonAlert.transform.position = shark.transform.position;//new Vector3(shark.transform.position.x, 4);
    }

    void TurnOffAlert()
    {
        Destroy(harpoonAlert);
        //harpoonAlert.GetComponent<SpriteRenderer>().enabled = false;
    }
}
