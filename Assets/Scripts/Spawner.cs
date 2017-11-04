using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject toSpawn;
    public float spawnLatency;
    public float nextSpawnTime = 1;

    void Update()
    {
        if (nextSpawnTime < Time.time)
        {
            nextSpawnTime = Time.time + spawnLatency * Random.Range(1f, 3f);
            Instantiate(toSpawn);
            toSpawn.transform.position = new Vector3(Random.Range(-2f, 2f), -10);
        }
    }
}
