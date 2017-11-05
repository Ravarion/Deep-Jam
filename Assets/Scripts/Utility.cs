using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ScreenDimensions
{
    public ScreenDimensions(ScreenDimensions copy)
    {
        left = copy.left;
        top = copy.top;
        right = copy.right;
        bottom = copy.bottom;
    }

    public float left;
    public float top;
    public float right;
    public float bottom;
}

public class Utility : MonoBehaviour {

    public float difficulty; //A number from 0 to 1, 0 being easiest

    private ScreenDimensions screenDimensions;

	void Start ()
    {
        FindScreenDimensions();
    }

    private void Update()
    {
        difficulty = Sigmoid(Time.timeSinceLevelLoad/8);
    }

    private void FindScreenDimensions()
    {
        screenDimensions.left = Camera.main.ViewportToWorldPoint(new Vector3(0, 0)).x;
        screenDimensions.bottom = Camera.main.ViewportToWorldPoint(new Vector3(0, 0)).y;
        screenDimensions.top = Camera.main.ViewportToWorldPoint(new Vector3(1, 1)).y;
        screenDimensions.right = Camera.main.ViewportToWorldPoint(new Vector3(1, 1)).x;
    }

    public ScreenDimensions GetScreenDimensions()
    {
        return screenDimensions;
    }

    //Formula: 1/(1 + e^(-val))
    private float Sigmoid(float val)
    {
        if (float.IsNaN(val))
        {
            print("Sigmoid Value Error: NAN");
        }
        float result = 1f / (1f + Mathf.Exp(-val) == 0 ? 0.0001f : 1f + Mathf.Exp(-val));
        if (float.IsNaN(result))
        {
            print("Sigmoid Result Error: NAN");
        }
        return result;
    }
}
