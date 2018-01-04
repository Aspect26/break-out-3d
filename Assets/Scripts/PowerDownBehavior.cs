using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerDownBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision other)
    {
        GameObject.Find("PowerDownSound").GetComponent<AudioSource>().Play();

        Destroy(transform.root.gameObject);

        GameObject ball = other.gameObject as GameObject;
        BallBehavior ballScript = ball.GetComponent<BallBehavior>();

        ballScript.speed.x *= 1.5f;
        ballScript.speed.y *= 1.5f;
        ballScript.speed.z *= 1.5f;
    }
}
