using System;
using System.Collections.Generic;

using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	// Players life
	public Texture playersHealthTexture;
	//Control screen position of texture
	public float screenPositionX;
	public float screenPositionY;
	// Controles icon size on screen
	public int iconSizeX = 25;
	public int iconSizeY = 25;
	//Starting lifes or batteries 
	public int playersHealth = 1;
	public Texture2D[] batteryStatus;
	double shellLife = 10.0;

	bool pauseMenu;

			
	public static float timeLeft = 10.0f;
		

	void Update(){
		if (Input.GetKeyDown (KeyCode.P) && !pauseMenu) {
			pauseMenu = true;
		} else if (Input.GetKeyDown (KeyCode.P)) {
			pauseMenu = false;
		}


		if (LinkController.flashlightOn) timeLeft -= Time.deltaTime;


		if (timeLeft <= 0.0f){
		
			// End the level here.
			//print( "You ran out of time"+ (int)timeLeft);
		
		} else {
			//print("Time left = " + (int)timeLeft + " seconds" );
		
		}

	}

	
	// Update is called once per frame
	void OnGUI () {

		// Controls Players Heath Textures
		for (int h = 2; h < playersHealth; h++) {
			GUI.DrawTexture(new Rect (screenPositionX + ( h * iconSizeX ), screenPositionY, iconSizeX *2, iconSizeY*2 ), 
			                batteryStatus[(( timeLeft > shellLife )?((int)Math.Floor((double)timeLeft /(double)shellLife)):
			                0)], ScaleMode.ScaleToFit, true, 0);
		}

		if (pauseMenu) {
	
			if (GUI.Button (new Rect(Screen.width * .25f, Screen.height * .4f, Screen.width * .5f, Screen.height * .1f ), "SAVE")){
				print ("SAVED GAME");
				PlayerPrefs.SetInt ("Player Health", playersHealth);
			}
			if (GUI.Button (new Rect(Screen.width * .25f, Screen.height * .5f, Screen.width * .5f, Screen.height * .1f ), "DISPLAY")){
				print ("DISPLAYED SAVED ITEMS");
				print(PlayerPrefs.GetInt ("Player Health"));
			}
		}
	}
 	public void SaveGame(){PlayerPrefs.SetInt ("Player Health", playersHealth);}
}
