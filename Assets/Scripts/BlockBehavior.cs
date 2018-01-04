﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision other)
    {
        GameObject.Find("BreakSound").GetComponent<AudioSource>().Play();
        Destroy(transform.root.gameObject);
    }
}
