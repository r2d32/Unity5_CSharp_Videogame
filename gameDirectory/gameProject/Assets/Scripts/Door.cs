using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
	public GameManager gameManager;

	void OnTriggerEnter2D (Collider2D other){
		gameManager.SaveGame();
		Application.LoadLevel("Scene1");
	}
}
