using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
	public GameManager gameManager;

	void OnTriggerEnter2D (Collider2D other){
		if(other.tag == "character"){
			gameManager.SaveGame();
			gameManager.lastLevel = 2;
			Application.LoadLevel("Scene2");
			PlayerPrefs.SetInt("levelUnlock", 2);
		}
	}
}
