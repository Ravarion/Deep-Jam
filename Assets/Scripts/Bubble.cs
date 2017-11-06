using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour {

    private float swimSpeed;

    void Start()
    {
        float scale = Random.Range(0.05f, 0.2f);
        transform.localScale = new Vector3(scale, scale, 1);
        swimSpeed = Random.Range(.01f, .05f);
    }

    void Update()
    {
        transform.Translate(new Vector3(0, swimSpeed, 0));
        if (transform.position.y > 10)
        {
            Destroy(gameObject);
        }
    }
}
