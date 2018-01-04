using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision other)
    {
        GameObject.Find("PowerUpSound").GetComponent<AudioSource>().Play();
        Destroy(transform.root.gameObject);
        GameObject go = Instantiate(Resources.Load("Ball")) as GameObject;
    }
}
