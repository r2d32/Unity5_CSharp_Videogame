using UnityEngine;
using System.Collections;

public class Chest : MonoBehaviour {

	/********** Chest Variables **********/
	public Animator chestAnimator;
	public GameObject[] itemsHeld;
	
	/********** METHOD TO OPEN CHEST **********/
	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "character" && Input.GetKeyDown (KeyCode.E)) {
			chestAnimator = GetComponent<Animator>(); 
			chestAnimator.SetBool("closed", false);
			ReleaseItems();
		}
	}
	void ReleaseItems(){
		foreach (GameObject item in itemsHeld) {
			//item.collider2D.enabled
			item.GetComponent<SpriteRenderer>().enabled = true;
			item.GetComponent<Collider2D>().enabled = true;
		}
	}

	void Update () {
	
	}
}
