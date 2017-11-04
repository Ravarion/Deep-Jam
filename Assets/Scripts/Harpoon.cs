using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harpoon : MonoBehaviour {

    public GameObject harpoonAlertPrefab;

    public GameObject harpoonAlert;

    public float alertTimer;
    public float minAlertTimer;
    public float maxAlertTimer;
    public float attackingTimer;
    public float minAttackingTimer;
    public float maxAttackingTimer;
    private bool attacking = false;

    public Vector3 desiredLocation;
    public float minAttackingSpeed;
    public float maxAttackingSpeed;
    public float floatingSpeed;
    public float minAimingSpeed;
    public float maxAimingSpeed;
    public bool desiredLocationMet = false;

    private GameObject shark;
    private Utility utility;
    private float screenTop;

	void Start ()
    {
        utility = FindObjectOfType<Utility>();
        alertTimer = minAlertTimer + (maxAlertTimer - minAlertTimer) * utility.difficulty;
        screenTop = utility.GetScreenDimensions().top;
        harpoonAlert = Instantiate(harpoonAlertPrefab);
        harpoonAlert.transform.position = new Vector3(Random.Range(utility.GetScreenDimensions().left, utility.GetScreenDimensions().right),
            screenTop, 0);
        shark = FindObjectOfType<Shark>().gameObject;
        transform.position = new Vector3(0,10);
        AlertPlayer();
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
                attackingTimer = minAttackingTimer + (maxAttackingTimer - minAttackingTimer) * utility.difficulty;
                transform.position = new Vector3(harpoonAlert.transform.position.x, transform.position.y);
                desiredLocation = new Vector3(harpoonAlert.transform.position.x, 0);

                //Stop harpoon alert from flashing
                harpoonAlert.GetComponent<Alert>().SetShouldFlash(true);
            }
        }
        else if(attackingTimer > 0)
        {
            attackingTimer -= Time.deltaTime;
        }
        else
        {
            if (Vector2.Distance(transform.position, desiredLocation) < minAttackingSpeed + (maxAttackingSpeed - minAttackingSpeed) * utility.difficulty)
            {
                desiredLocationMet = true;
                TurnOffAlert();
            }
            if (!desiredLocationMet)
            {
                transform.position = Vector3.MoveTowards(transform.position, desiredLocation, minAttackingSpeed +
                    (maxAttackingSpeed - minAttackingSpeed) * utility.difficulty);
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
        //harpoonAlert.transform.position = new Vector3(shark.transform.position.x, screenTop - 
        //    harpoonAlert.GetComponent<CircleCollider2D>().bounds.center.y);
        harpoonAlert.transform.position = Vector3.MoveTowards(harpoonAlert.transform.position,
            new Vector3(shark.transform.position.x, screenTop), minAimingSpeed + (maxAimingSpeed - minAimingSpeed) * utility.difficulty);
    }

    void TurnOffAlert()
    {
        Destroy(harpoonAlert);
        //harpoonAlert.GetComponent<SpriteRenderer>().enabled = false;
    }
}

