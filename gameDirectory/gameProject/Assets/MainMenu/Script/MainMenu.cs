/// <summary>
/// Main menu.
/// Attached to Main Camera.
/// </summary>

using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public GUIStyle btn1;
	public GUIStyle btn2;
	public bool btnImages;
    public bool mainMenu = true;
    void start(){
        Time.timeScale =1;
    }

    void update(){
        print(Time.deltaTime);
    }

	void OnGUI  () {

		//Display Background Texture


		if (btnImages) {

            if (mainMenu){    
			    if (GUI.Button (new Rect (Screen.width * .5f - 150, Screen.height * .63f, 300,200), "", btn1)) {
                    Application.LoadLevel("Start");
			    }
            }
            if (!mainMenu){
                if (GUI.Button (new Rect (Screen.width * .5f - 150, Screen.height * .77f,  300,200), "", btn2)) {
                    Application.LoadLevel("MainMenu");
			    }
            }
		} else { 

			//Display Buttons
			if (GUI.Button (new Rect (Screen.width * .4f, Screen.height * .2f, Screen.width * .2f, Screen.height * .1f), "Play ")) {
				print ("helo");
				Application.LoadLevel("Start");
			}
			if (GUI.Button (new Rect (Screen.width * .4f, Screen.height * .85f, Screen.width * .2f, Screen.height * .1f), "Game Options")) {
				print ("helo");
			}
		}
	
	}

}
