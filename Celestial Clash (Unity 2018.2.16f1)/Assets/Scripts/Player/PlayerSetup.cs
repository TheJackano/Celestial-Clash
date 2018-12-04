using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(PlayerManager))]

public class PlayerSetup : NetworkBehaviour {

	[SerializeField]
	Behaviour[] componentsToDisable;


	// Use this for initialization
	void Start ()
	{
		if (!isLocalPlayer)
		{
			DisableComponents ();
		}
	}

	void DisableComponents()
	{
		for (int i = 0; i < componentsToDisable.Length; i++)
		{
			componentsToDisable[i].enabled = false;
		}
	}

	public override void OnStartClient()
	{
		base.OnStartClient ();

		string netID = GetComponent<NetworkIdentity>().netId.ToString();
		PlayerManager player = GetComponent<PlayerManager>();

		GameManager.RegisterPlayer (netID, player);
	}
}