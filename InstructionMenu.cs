using UnityEngine;
using System.Collections;

public class InstructionMenu : MonoBehaviour {

	public string instructionmenu;

	public void Instructionmenu(){

		Application.LoadLevel (instructionmenu);
	}
}
