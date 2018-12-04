using UnityEngine;
using System.Collections;

public class HealthPickup : MonoBehaviour {
	public int healthToGive;
	//public GameObject healthParticle;

	void OnTriggerEnter2D(Collider2D other){
		//Instantiate (healthParticle,transform.position,transform.rotation);
		if (other.GetComponent<PlayerController> () == null)
			return;
		HealthManager.HurtPlayer (-healthToGive);
		//Instantiate (healthParticle,transform.position,transform.rotation);
		Destroy (gameObject);

	}
	// Use this for initialization

}
