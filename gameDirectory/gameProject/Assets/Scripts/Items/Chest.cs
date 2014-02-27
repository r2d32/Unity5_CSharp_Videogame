using UnityEngine;
using System.Collections;

public class Chest : MonoBehaviour {

	/********** Chest Variables **********/
	public Animator chestAnimator;
	public GameObject[] itemsHeld;
	
	/********** METHODS TO OPEN CHEST **********/
	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "character" && Input.GetButtonDown("Action")) {
			chestAnimator = GetComponent<Animator>(); 
			chestAnimator.SetBool("closed", false);
			ReleaseItems();
		}
	}
	void ReleaseItems(){
		foreach (GameObject item in itemsHeld) {
			item.GetComponent<SpriteRenderer>().enabled = true;
			item.GetComponent<Collider2D>().enabled = true;
		}
	}
	void Update () {
	}
}
