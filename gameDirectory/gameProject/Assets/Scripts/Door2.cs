using UnityEngine;
using System.Collections;

public class Door2 : MonoBehaviour {
	public GameManager gameManager;
	
	void OnTriggerEnter2D (Collider2D other){
		gameManager.SaveGame();
		gameManager.lastLevel = 2;
		Application.LoadLevel("MainMenu");
	}
}
