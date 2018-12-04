using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlayerController : MonoBehaviour {
	
	Rigidbody rb;
    private int thrustPower = 2;

	// Use this for initialization
	void Start ()
	{
		rb = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		if (Input.GetKey("w"))
		{
			rb.AddForce(transform.forward* thrustPower);
		}
		if (Input.GetKey("d"))
		{
			rb.AddTorque(transform.up* thrustPower/2);
		}
		if (Input.GetKey("a"))
		{
			rb.AddTorque(transform.up*(-thrustPower/2));
		}
	}
}
