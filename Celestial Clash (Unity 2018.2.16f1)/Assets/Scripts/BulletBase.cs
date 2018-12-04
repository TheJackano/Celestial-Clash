using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(Rigidbody))]

public class BulletBase : NetworkBehaviour {

    Rigidbody rb;

    private int power = 10;

    void Start () {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.AddForce(this.gameObject.transform.forward* power, ForceMode.Impulse);
	}
	
	void Update () {
		//hit.collider.name
	}
}
