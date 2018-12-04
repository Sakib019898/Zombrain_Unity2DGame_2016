using UnityEngine;
using System.Collections;

public class StoryMenu : MonoBehaviour {
	public string story;

	public void Storymenu(){

		Application.LoadLevel (story);
	}

}
