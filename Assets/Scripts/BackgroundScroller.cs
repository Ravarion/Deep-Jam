using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour {

    public Sprite[] depths;
    public Sprite[] transitions;

    public int backgroundRepetitions;

    private int curDepth;

    void Start()
    {
        //SetupBackgrounds();
    }
	
	void Update ()
    {
        transform.Translate(Vector2.up * .1f);
        if(transform.position.y > 430)
        {
            FindObjectOfType<Shark>().GameOver();
        }
	}

    void SetupBackgrounds()
    {
        float yPos = 0;
        for(int i = 0; i < depths.Length; i++)
        {
            for(int j = 0; j < backgroundRepetitions; j++)
            {
                GameObject newBg = new GameObject();
                newBg.name = "Depth" + i + "Rep" + j;
                newBg.transform.SetParent(gameObject.transform);
                newBg.AddComponent<SpriteRenderer>();
                newBg.GetComponent<SpriteRenderer>().sprite = depths[i];
                transform.Translate(Vector2.down * yPos);
                yPos += .5f;
            }
            if(i < transitions.Length)
            {
                GameObject newTransition = new GameObject();
                newTransition.name = "Transition" + i;
                newTransition.transform.SetParent(gameObject.transform);
                newTransition.AddComponent<SpriteRenderer>();
                newTransition.GetComponent<SpriteRenderer>().sprite = transitions[i];
                transform.Translate(Vector2.up * -yPos);
            }
        }
    }
}
