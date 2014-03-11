using UnityEngine;
using System.Collections;

public class waterDrop : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "character"){
			other.rigidbody2D.velocity = new Vector2(0,-400f);
		} 
		Destroy(gameObject);
	}
}


