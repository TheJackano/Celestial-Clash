using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerAttack : NetworkBehaviour {

    [SerializeField]
    private GameObject bulletPrefab;

    private float timeLastFired = 0f;
    private float delayBetweenFires = 0.2f;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (Input.GetKey("space") && isLocalPlayer && (Time.time > timeLastFired + delayBetweenFires))
        {
            CmdFire();
        }
    }
    [Command]
    void CmdFire()
    {
        timeLastFired = Time.time;
        var bullet = Instantiate(bulletPrefab, this.gameObject.transform.GetChild(1).GetChild(0).position, this.gameObject.transform.GetChild(1).GetChild(0).rotation);
        NetworkServer.Spawn(bullet);
    }
}
