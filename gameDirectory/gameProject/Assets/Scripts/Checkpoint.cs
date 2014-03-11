using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		
		if (other.gameObject.tag == "character") {
			LinkController.respawnX = this.transform.position.x;
			LinkController.respawnY = this.transform.position.y;

		}
	}
}
