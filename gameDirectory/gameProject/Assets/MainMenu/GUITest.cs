//C#
using UnityEngine;
using System.Collections;

public class GUITest : MonoBehaviour {
	int sWidth = Screen.width;
	int sHeight = Screen.height;
	public GUIStyle style;
	public GUIStyle buttonStyle;
	public GUIStyle title;
	
	void OnGUI () {
		// Make a background box
		// this is how it goes (Screen.width,Screen.height,width,height)
		GUI.Box(new Rect( (sWidth/2)-200, (sHeight/2)-200,400,400), "JUST DARK", style);

		GUI.Box(new Rect( (sWidth/2)-400, (sHeight/2)-210,800,180), "JUST DARK", title);

		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if (GUI.Button (new Rect ((sWidth / 2) - 126, (sHeight / 2) +33, 252, 66), "PLAY", buttonStyle)) {
			Application.LoadLevel ("LevelSelect");
		}
		// Make the second button.
		if(GUI.Button(new Rect((sWidth/2)-126,(sHeight/2)+105,252,66), "NOTHING", buttonStyle)) {
			Application.LoadLevel("MainMenu");
		}
	}

}