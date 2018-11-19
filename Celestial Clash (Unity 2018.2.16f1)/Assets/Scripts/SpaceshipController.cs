using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipController : MonoBehaviour {

	Rigidbody rb;
	//string[] keys = new string[] {"w", "a","s","d"};

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody>();
		}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if (Input.GetKey("w"))
		{
			print("w key was pressed");
			rb.AddForce(transform.forward*20);
		}
		if (Input.GetKey("d"))
		{
			print("d key was pressed");
			rb.AddTorque(transform.up*5);
		}
		if (Input.GetKey("a"))
		{
			print("a key was pressed");
			rb.AddTorque(transform.up*(-5));
		}
	}

	static void SetControlScheme()
	{
		
	}
}
