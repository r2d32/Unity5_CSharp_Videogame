using UnityEngine;
using System.Collections;

public class Doors : MonoBehaviour {

	/********** Door Variables **********/
	public Animator doorAnimator;
	public Collider2D doorCollider;

	
	/********** METHODS TO OPEN DOOR **********/
	void OpenDoor (){
		doorAnimator = GetComponent<Animator>(); 
		doorAnimator.SetBool("closed", false);
		doorCollider.enabled = false;
	}
	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "character")
			OpenDoor ();
	}
	void Update () {
	}
}
