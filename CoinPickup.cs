﻿using UnityEngine;
using System.Collections;

public class CoinPickup : MonoBehaviour {
	public int pointsToAdd;
	public GameObject coinParticle;
	void OnTriggerEnter2D(Collider2D other){

		if (other.GetComponent<PlayerController> () == null)
			return;
		ScoreManager.AddPoints (pointsToAdd);
		Instantiate (coinParticle,transform.position,transform.rotation);
		Destroy (gameObject);


	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
