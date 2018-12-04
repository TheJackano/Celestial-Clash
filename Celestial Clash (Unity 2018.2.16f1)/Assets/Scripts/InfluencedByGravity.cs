using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class InfluencedByGravity : MonoBehaviour {
	
	Rigidbody rb;
	public GameObject[] gravityWells;

	void Start () {
		rb = gameObject.GetComponent<Rigidbody>();

		//Adds all gravity wells to the array
		gravityWells = GameObject.FindGameObjectsWithTag ("GravityWell");
	}

	void FixedUpdate ()
	{

		// For loop used to apply the code inside to all gravity wells
		for (int i = 0; i <gravityWells.Length; i++) 
		{
			// Gets the strength of gravity value from the gravity well
			int strength = gravityWells[i].gameObject.GetComponent<GravityWellProperties>().gravityStrength;

			// Figures out the distance between this object and the gravity well
			float distance = Vector3.Distance(gravityWells [i].transform.position, this.transform.position);

			// Gets the distance where gravity should no longer affect this object
			//int falloff = gravityWells[i].gameObject.GetComponent<GravityWellProperties>().gravityFalloffDistance;

			// Applies the force in the direction of the gravity well (Force increases as the distance closes)
			rb.AddForce (((gravityWells [i].transform.position - this.transform.position).normalized * strength) / (distance * distance));
            //this.transform.position = new Vector3(this.transform.position.x, 0,this.transform.position.z);
		

			//Debug.Log ("Strength: " + strength);
			//Debug.Log ("Distance: " + distance);
			//Debug.Log ("Force: " + ((gravityWells [i].transform.position - this.transform.position).normalized * strength)/(distance * distance));

			// Needs a script that scales the size of influence and strength together
			// 2K Srength has 30 distance threshold 2k/30 = 66
			// Maybe put falloff instead of the 66
		}
	}
}
