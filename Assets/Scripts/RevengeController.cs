using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevengeController : MonoBehaviour {

    public GameObject sharkObject;

    private void Start()
    {
        
    }

    private void OnMouseDrag()
    {
        Vector2 touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (true)
        {
			if(touchPosition.y > 1.5f)
				sharkObject.GetComponent<Shark>().desiredPosition = new Vector2(touchPosition.x, 1.5f);
			else
				sharkObject.GetComponent<Shark>().desiredPosition = new Vector2(touchPosition.x, touchPosition.y);
        }
    }
}
