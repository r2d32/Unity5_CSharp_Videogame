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
	public int lastLevel = 1;
	// Controles icon size on screen
	public int iconSizeX = 25;
	public int iconSizeY = 25;
	//Starting lifes or batteries 
	public static int playersHealth = 3;
	public int playersBatteries = 1;
	public Texture2D[] batteryStatus;

	public static List<Texture2D> characterKeyItems = new List<Texture2D>();

	public 
	double shellLife = 10.0;
	// Setting the grace period
	public static float gracePeriod = 0.0f;

	bool pauseMenu;

			
	public static float timeLeft = 49.0f;
		

	void Update(){

		if (Input.GetKeyDown (KeyCode.P) && !pauseMenu) {
			pauseMenu = true;
		} else if (Input.GetKeyDown (KeyCode.P)) {
			pauseMenu = false;
		}
		if (Input.GetKey ("escape")) {
			Application.Quit();
			PlayerPrefs.DeleteKey("levelUnlock");
		}
		// Update variable that use time
		if (LinkController.flashlightOn) timeLeft -= Time.deltaTime;
		if (gracePeriod > 0.0)gracePeriod -= Time.deltaTime;




	}

	
	// Update is called once per frame
	void OnGUI () {
		// Controls Players Battery Textures
		for (int h = 0; h < playersBatteries; h++) {
			GUI.DrawTexture(new Rect (screenPositionX , screenPositionY + iconSizeY, iconSizeX * 2, iconSizeY*2 ), 
			                batteryStatus[(( timeLeft > shellLife )?((int)Math.Floor((double)timeLeft /(double)shellLife)):
			                0)], ScaleMode.ScaleToFit, true, 0);
		}
		//Controls player health textures
		for (int h = 0; h < playersHealth; h++) {
			GUI.DrawTexture(new Rect (screenPositionX + ( h * iconSizeX ), screenPositionY, iconSizeX , iconSizeY), 
			                playersHealthTexture, ScaleMode.ScaleToFit, true, 0);
		}
		// Controls player keyItems
		for (int e = 0; e < characterKeyItems.Count; e++) {

			GUI.DrawTexture(new Rect (screenPositionX + (Screen.width/2) + (e * iconSizeX ) , screenPositionY, iconSizeX , iconSizeY), 
			                characterKeyItems[e], ScaleMode.ScaleToFit, true, 0);
		}


		if (pauseMenu) {

	
			if (GUI.Button (new Rect(Screen.width * .25f, Screen.height * .4f, Screen.width * .5f, Screen.height * .1f ), "SAVE")){
				print ("SAVED GAME");
				PlayerPrefs.SetInt ("Player Health", playersHealth);
			}

			if (GUI.Button (new Rect(Screen.width * .25f, Screen.height * .5f, Screen.width * .5f, Screen.height * .1f ), "QUIT GAME")){
				print ("QUIT GAME");
				print(PlayerPrefs.GetInt ("Player Health"));
				PlayerPrefs.DeleteKey("levelUnlock");
				Application.Quit();
			}
			//if (GUI.Button (new Rect(Screen.width * .25f, Screen.height * .5f, Screen.width * .5f, Screen.height * .1f ), "DISPLAY")){
				//print ("DISPLAYED SAVED ITEMS");
				//print(PlayerPrefs.GetInt ("Player Health"));
			//}
		}
	}
 	public void SaveGame(){PlayerPrefs.SetInt ("Player Health", playersHealth);}
}
