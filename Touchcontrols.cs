using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touchcontrols : MonoBehaviour {
	private PlayerController thePlayer;

	// Use this for initialization
	void Start () {
		thePlayer = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	public void Left(){

		thePlayer.Move (-1);

	}
	public void Right(){

		thePlayer.Move (1);

	}
	public void Unpressed(){

		thePlayer.Move (0);

	}
	public void Shoot(){

		thePlayer.Fire();

	}


	public void Jump(){
		if(thePlayer.groundCheck==true)
		thePlayer.Jump();

	}
}
