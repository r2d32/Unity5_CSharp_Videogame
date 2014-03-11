using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	/********** GUI VARIABLES **********/
	public Texture playersHealthTexture;
	public Texture playerCoinTexture;
	public Texture playerRocksTexture;
	public float screenPositionX;
	public float screenPositionY;
	public int iconSizeX = 25;
	public int iconSizeY = 25;
	public double batteryShellLife = 10.0;
	public int playersBatteries = 1;
	public Texture2D[] batteryStatus;
	private bool pauseMenuActive;
	public static float gameTime;
	public GUIStyle guiText;

	/********** CHARACTER INFO *************/
	public static int playersHealth = 3;
	public static List<Texture2D> characterKeyItems = new List<Texture2D>();
	public static float gracePeriod = 0.0f;
	public int lastLevel = 1;
	public static float batteryTimeLeft = 49.0f;
		
	/********** UPDATES VARIABLES THAT USE TIME **********/
	void Update(){
		gameTime += Time.deltaTime;

		if (Input.GetButtonDown("Pause") && !pauseMenuActive) {
			pauseMenuActive = true;
		} else if (Input.GetButtonDown("Pause")) {
			pauseMenuActive = false;
		}

		if (Input.GetKey ("escape")) {
			Application.Quit();
			PlayerPrefs.DeleteKey("levelUnlock");
		}

		if (LinkController.flashlightOn) batteryTimeLeft -= Time.deltaTime;

		if (gracePeriod > 0.0)gracePeriod -= Time.deltaTime;
	}

	
	/********** ALL GUI STUFF GOES HERE **********/
	void OnGUI () {

		/********** ON GAME GUI **********/

		// HEALTH 
		for (int h = 0; h < playersHealth; h++) {
			GUI.DrawTexture(new Rect (screenPositionX + ( h * iconSizeX ), screenPositionY, iconSizeX , iconSizeY), 
			                playersHealthTexture, ScaleMode.ScaleToFit, true, 0);
		}

		// COLLECTABLES
		GUI.DrawTexture(new Rect (screenPositionX + ( 4 * iconSizeX ), screenPositionY, iconSizeX , iconSizeY), 
		                playerCoinTexture, ScaleMode.ScaleToFit, true, 0);
		GUI.Label(new Rect (screenPositionX + ( 5 * iconSizeX ), screenPositionY, iconSizeX , iconSizeY), ":" + LinkController.numOfCoins, guiText);

		GUI.DrawTexture(new Rect (screenPositionX + ( 6 * iconSizeX ), screenPositionY, iconSizeX , iconSizeY), 
		                playerRocksTexture, ScaleMode.ScaleToFit, true, 0);
		GUI.Label(new Rect (screenPositionX + ( 7 * iconSizeX ), screenPositionY, iconSizeX , iconSizeY), ":" + LinkController.numOfRocks, guiText);

		for (int h = 0; h < playersBatteries; h++) {
			GUI.DrawTexture(new Rect (screenPositionX , screenPositionY + iconSizeY, iconSizeX * 2, iconSizeY*2 ), 
			                batteryStatus[(( batteryTimeLeft > batteryShellLife )?((int)Math.Floor((double)batteryTimeLeft /(double)batteryShellLife)):
			               0)], ScaleMode.ScaleToFit, true, 0);
		}

		// KEY ITEMS 
		for (int e = 0; e < characterKeyItems.Count; e++) {

			GUI.DrawTexture(new Rect (screenPositionX + (Screen.width/2) + (e * iconSizeX ) , screenPositionY, iconSizeX , iconSizeY), 
			                characterKeyItems[e], ScaleMode.ScaleToFit, true, 0);
		}

		// PAUSE MENU GUI
		if (pauseMenuActive) {
			Time.timeScale =0;
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
		} else { Time.timeScale =1; }
	}
	/********** METHODS TO USE ON GUI ACTIONS **********/
 	public void SaveGame(){PlayerPrefs.SetInt ("Player Health", playersHealth);}
}
