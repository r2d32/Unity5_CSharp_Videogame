using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    /********** GUI VARIABLES **********/
    public Texture playersHealthTexture;
    public Texture playerCoinTexture;
    public Texture backGUI;
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
    public GUIStyle guiTextSpell;

    /********** CHARACTER INFO *************/
    public static int playersHealth = 7;
    public static List<Texture2D> characterKeyItems = new List<Texture2D>();
    public static float gracePeriod = 0.0f;
    public int lastLevel = 1;
    public static float batteryTimeLeft = 49.0f;
		
        
    /********** GAME NPCS **********/
    public RespawnableNPCs[] respawnableNPCs;
    public Rigidbody2D[] npcObjectPrefabs;
    public String[] npcKinds;
   

    void start(){
        RespondDeadNpcs();
    }
    
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

        if (LinkController.flashlightOn && LinkController.characterHasFlashlight) batteryTimeLeft -= Time.deltaTime;

        if (gracePeriod > 0.0)gracePeriod -= Time.deltaTime;
    }

	
    /********** ALL GUI STUFF GOES HERE **********/
    void OnGUI () {

        /********** ON GAME GUI **********/
        //Back state GUI
        GUI.DrawTexture(new Rect (10, 10, 325 , 88), 
                        backGUI, ScaleMode.ScaleToFit, true, 0);

        // HEALTH 
        for (int h = 0; h < playersHealth; h++) {
            GUI.DrawTexture(new Rect (30 + ( h * 30 ), 24, 30 , 20), 
                            playersHealthTexture, ScaleMode.ScaleToFit, true, 0);
        }

        // COLLECTABLES
        GUI.DrawTexture(new Rect (45, 60, iconSizeX , iconSizeY), 
                        playerCoinTexture, ScaleMode.ScaleToFit, true, 0);
        GUI.Label(new Rect (66, 59, iconSizeX , iconSizeY), "" + LinkController.numOfCoins, guiText);

        GUI.DrawTexture(new Rect (133, 60, iconSizeX , iconSizeY), 
                        playerRocksTexture, ScaleMode.ScaleToFit, true, 0);
        GUI.Label(new Rect (160, 60, iconSizeX , iconSizeY), "" + LinkController.numOfRocks, guiTextSpell);

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

    /********** RESPOND NPC'S SCRIPT **********/
    public void RespondDeadNpcs(){
        StartCoroutine(killEnemies());    
        foreach(RespawnableNPCs npc in respawnableNPCs){
            int npcKind = System.Array.IndexOf(npcKinds,npc.kind);
            if(!npc.npcIsAlive){
                Rigidbody2D bPrefab = Instantiate (( npcObjectPrefabs[npcKind] ), npc.npcLocation.position, Quaternion.identity) as Rigidbody2D;
                //npc.npcIsAlive;

            }
        }    
    }
    IEnumerator killEnemies(){
    
        GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");
        print("wiped");
        foreach(GameObject enemy in enemies){
            Destroy(enemy);
        }
        yield return new WaitForSeconds(1f);
    }
}
