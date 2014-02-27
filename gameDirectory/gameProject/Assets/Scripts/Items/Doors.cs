using UnityEngine;
using System.Collections;

public class Doors : MonoBehaviour {

	/********** Door Variables **********/
	public Animator doorAnimator;
	
	/********** METHODS TO OPEN DOOR **********/
	void OpenDoor (){
		doorAnimator = GetComponent<Animator>(); 
		doorAnimator.SetBool("closed", false);
		this.GetComponent<Collider2D>().enabled = false;
	}
	void Update () {
	}
}
