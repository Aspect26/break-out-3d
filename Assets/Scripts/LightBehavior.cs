using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBehavior : MonoBehaviour {

    enum Phase
    {
        Red, Green, Blue
    }

    private Color lightColor;
    private Phase phase;
    private float speed = 0.01f;

    // Use this for initialization
    void Start () {
        this.lightColor = GetComponent<Light>().color;
        this.lightColor.r = 1.0f;
        this.lightColor.g = 0.0f;
        this.lightColor.b = 0.0f;
        this.phase = Phase.Blue;
    }
	
	// Update is called once per frame
	void Update () {
        if (this.phase == Phase.Blue)
        {
            if (lightColor.b < 1.0f)
            {
                lightColor.b = (lightColor.b + speed < 1.0f) ? lightColor.b + speed : 1.0f;
            }
            else if (lightColor.r > 0.0f)
            {
                lightColor.r = (lightColor.r - speed > 0.0f) ? lightColor.r - speed : 0.0f;
            }
            else
            {
                this.phase = Phase.Green;
            }
        }
        else if (this.phase == Phase.Green)
        {
            if (lightColor.g < 1.0f)
            {
                lightColor.g = (lightColor.g + speed < 1.0f) ? lightColor.g + speed : 1.0f;
            }
            else if (lightColor.b > 0.0f)
            {
                lightColor.b = (lightColor.b - speed > 0.0f) ? lightColor.b - speed : 0.0f;
            }
            else
            {
                this.phase = Phase.Red;
            }
        }
        else
        {
            if (lightColor.r < 1.0f)
            {
                lightColor.r = (lightColor.r + speed < 1.0f) ? lightColor.r + speed : 1.0f;
            }
            else if (lightColor.g > 0.0f)
            {
                lightColor.g = (lightColor.g - speed > 0.0f) ? lightColor.g - speed : 0.0f;
            }
            else
            {
                this.phase = Phase.Blue;
            }
        }
        GetComponent<Light>().color = lightColor;
    }
}
