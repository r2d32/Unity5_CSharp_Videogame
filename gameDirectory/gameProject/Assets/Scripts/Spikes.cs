using UnityEngine;
using System.Collections;

public class Spikes : MonoBehaviour {
			
	IEnumerator OnTriggerEnter2D(Collider2D other){
			
		if (other.gameObject.tag == "character") {
			LinkController.dead = true;
			yield return new WaitForSeconds(3);
			GameManager.playersHealth = 0 ;
		}
	}
}
