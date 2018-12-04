using UnityEngine;
using UnityEngine.Networking;

public class PlayerManager : NetworkBehaviour {

	[SerializeField]
	private int maxHealth = 100; //Might have to sync this for the slider to work

	[SyncVar]
	private int currentHealth;

	void Start()
	{
		SetDefaults();
	}
		
	public void SetDefaults()
	{
		currentHealth = maxHealth;
		Debug.Log (transform.name + " has " + currentHealth + " health");
	}
	public void TakeDamage (int amount)
	{
		currentHealth = amount;
	}
}
