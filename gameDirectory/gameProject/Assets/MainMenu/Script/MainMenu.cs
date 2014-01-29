/// <summary>
/// Main menu.
/// Attached to Main Camera.
/// </summary>

using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public Texture backgroundTexture;
	public GUIStyle btn1;
	public GUIStyle btn2;
	public bool btnImages;



	void OnGUI  () {

		//Display Background Texture
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), backgroundTexture);

		if (btnImages) {

			if (GUI.Button (new Rect (Screen.width * .25f, Screen.height * .5f, Screen.width * .5f, Screen.height * .1f), "", btn1)) {
				print ("helo");
				Application.LoadLevel("Scene1");
			}
			if (GUI.Button (new Rect (Screen.width * .25f, Screen.height * .7f, Screen.width * .5f, Screen.height * .1f), "", btn2)) {
				print ("helo");
			}
		} else { 

			//Display Buttons
			if (GUI.Button (new Rect (Screen.width * .25f, Screen.height * .5f, Screen.width * .5f, Screen.height * .1f), "Play Game")) {
				print ("helo");
				Application.LoadLevel("Scene1");
			}
			if (GUI.Button (new Rect (Screen.width * .25f, Screen.height * .7f, Screen.width * .5f, Screen.height * .1f), "Game Options")) {
				print ("helo");
			}
		}
	
	}

}
