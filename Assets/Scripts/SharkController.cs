using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkController : MonoBehaviour {

    public GameObject sharkObject;
    public Transform controlledObjectIcon;

    private void Start()
    {
        
    }

    private void OnMouseDrag()
    {
        Vector2 touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (true)
        {
            sharkObject.GetComponent<Shark>().desiredPosition = new Vector2(touchPosition.x, sharkObject.transform.position.y);
            controlledObjectIcon.position = new Vector2(touchPosition.x, controlledObjectIcon.position.y);
        }
    }
}
