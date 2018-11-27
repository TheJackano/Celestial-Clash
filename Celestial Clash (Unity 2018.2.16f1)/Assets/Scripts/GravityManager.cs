using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityManager : MonoBehaviour {

	Rigidbody rb;
	public GameObject[] GravityWells;

	void Start () {
		rb = gameObject.GetComponent<Rigidbody>();

		//Adds all gravity wells to the array
		GravityWells = GameObject.FindGameObjectsWithTag ("GravityWell");
	}

	void FixedUpdate () {

		// For loop used to apply the code inside to all gravity wells
		for (int i = 0; i <GravityWells.Length; i++) {
			// Gets the strength of gravity value from the gravity well
			int strength = GravityWells[i].gameObject.GetComponent<GravityWellProperties>().gravityStrength;

			// Figures out the distance between this object and the gravity well
			float distance = Vector3.Distance(GravityWells [i].transform.position, this.transform.position);

			// Gets the distance where gravity should no longer affect this object
			int falloff = GravityWells[i].gameObject.GetComponent<GravityWellProperties>().gravityFalloffDistance;


			if (distance < strength / 66) {
				// Applies the force in the direction of the gravity well (Force increases as the distance closes)
				rb.AddForce (((GravityWells [i].transform.position - this.transform.position).normalized
				* strength) / (distance * distance));
				Debug.Log ("Being influcend by gravity!");
			} else {
				Debug.Log("Out of the range of gravity!");
			}

			Debug.Log ("Strength: " + strength);
			Debug.Log ("Distance: " + distance);
			Debug.Log ("Force: " + ((GravityWells [i].transform.position - this.transform.position).normalized 
				* strength)/(distance * distance));

			//Needs a script that scales the size of influence and strength together
			// 2K Srength has 30 distance threshold 2k/30 = 66
			// Maybe put falloff instead of the 66
		}
	}
}
