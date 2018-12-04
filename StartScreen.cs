using UnityEngine;
using System.Collections;

public class StartScreen : MonoBehaviour {
	public GameObject startScreen;
	public PlayerController player;
	public string mainMenu;
	public float waitAfterStart;
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		startScreen.SetActive (true);
		if (startScreen.activeSelf) {
			waitAfterStart-= Time.deltaTime;

		}
		if (waitAfterStart < 0) {

			Application.LoadLevel (mainMenu);
		}

}
}
