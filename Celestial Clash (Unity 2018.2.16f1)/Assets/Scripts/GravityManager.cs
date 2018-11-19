using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityManager : MonoBehaviour {

	Rigidbody rb;
	public GameObject[] GravityWells;
	//Vector3 Strength = new Vector3(0.5,0.5,0.5);

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody>();
		GravityWells = GameObject.FindGameObjectsWithTag ("GravityWell");
		Debug.Log(GravityWells[0]);

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//ridgidbody.AddForce(Target.position - transform.position)

		for (int i = 0; i <GravityWells.Length; i++)
		{
			print ("Found well " + GravityWells[i].name);
			int strength = GravityWells[i].gameObject.GetComponent<GravityWellProperties>().gravityStrength;
			float distance = Vector3.Distance(GravityWells [i].transform.position, this.transform.position);
			float falloff = GravityWells[i].gameObject.GetComponent<GravityWellProperties>().gravityFalloffDistance;

			print (strength);
			print (distance);

			rb.AddForce (((GravityWells [i].transform.position - this.transform.position).normalized 
				* strength)/(distance * distance));
		}
	}
}
