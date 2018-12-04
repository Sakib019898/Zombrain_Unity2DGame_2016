using UnityEngine;
using System.Collections;

public class Mainmenu : MonoBehaviour {
	public string startLevel;
	public string levelSelect;
	public string instructions;

	public void NewGame(){

		Application.LoadLevel (startLevel);
	}
	public void LevelSelect(){
		Application.LoadLevel (levelSelect);

	}
	public void Instructions(){
		Application.LoadLevel (instructions);

	}
	public void QuitGame(){

		Debug.Log ("Game exited");
		Application.Quit ();

	}
}
