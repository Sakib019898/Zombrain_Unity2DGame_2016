using UnityEngine;
using System.Collections;

public class NinjaStarController : MonoBehaviour {
	public float speed;
	public PlayerController player;
	public GameObject enemyDeathEffect;
	public GameObject impactEffect;
	public int pointsForKill;
	public int damageToGive;
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();
		if (player.transform.localScale.x < 0)
			speed = -speed;
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (speed, GetComponent<Rigidbody2D> ().velocity.y);
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Enemy") {
			/*
			Instantiate (enemyDeathEffect, other.transform.position, other.transform.rotation);
			Destroy (other.gameObject);
			ScoreManager.AddPoints (pointsForKill);
			*/
			other.GetComponent<EnemyHealthManager> ().GiveDamage (damageToGive);
		}
		if (other.tag == "Boss") {
			other.GetComponent<BossHealthManager> ().GiveDamage (damageToGive);

		}
		if (other.tag == "Checkpoint")
			return;
		if (other.tag == "Coin")
			return;
		if (other.name == "Player")
			return;
		Instantiate (impactEffect, transform.position, transform.rotation);
		Destroy (gameObject);
		
	}
}
