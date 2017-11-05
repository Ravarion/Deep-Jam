using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject toSpawn;
    public float spawnLatency;
    public float nextSpawnTime;

    public bool scaleWithDifficulty;

    private Utility utility;

    private void Start()
    {
        nextSpawnTime = Time.time + spawnLatency;
        utility = FindObjectOfType<Utility>();
    }

    void Update()
    {
        if (nextSpawnTime < Time.time)
        {
            nextSpawnTime = Time.time + spawnLatency * Random.Range(0f, 7f) * (scaleWithDifficulty?(1 - utility.difficulty):1);
            Instantiate(toSpawn);
            toSpawn.transform.position = new Vector3(Random.Range(-2f, 2f), -10);
        }
    }
}
