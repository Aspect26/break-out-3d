using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour {

    public Vector3 speed;
    public Vector3 direction;
    public Rigidbody rb;
    public Vector3 movement;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        speed = new Vector3(0.5f, 0.5f, 0.5f);
        direction = new Vector3(-1f, 0.3f, 0.2f);
    }
	
	// Update is called once per frame
	void Update () {
        movement = new Vector3(speed.x * direction.x, speed.y * direction.y, speed.z * direction.z);
    }

    void FixedUpdate()
    {
        this.rb.velocity = movement;
    }

    void OnCollisionEnter(Collision other)
    {
        //Check if you have to be specific to an object to bounce
        Debug.Log("called");

        Vector3 bouncedVector = -2 * (Vector3.Dot(this.direction, other.contacts[0].normal)) * other.contacts[0].normal + this.direction;
        this.direction = bouncedVector;

    }

}
