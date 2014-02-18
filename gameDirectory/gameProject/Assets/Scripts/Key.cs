using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour {
	
	public Texture2D item;

	void OnTriggerEnter2D(Collider2D other){
		
		if (other.gameObject.tag == "character") {
			GameManager.characterKeyItems.Add(item);
			Destroy(gameObject);
		}
	}
}
