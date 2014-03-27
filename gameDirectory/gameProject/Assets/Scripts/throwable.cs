using UnityEngine;
using System.Collections;

public class throwable : MonoBehaviour {
	/********** DESCRIBES THE KIND OF TROWABLE *********/
	public bool isWaterDrop = true;
	public bool isDart = false;

	/********** HANDLES THROWABLE COLLISION **********/
	void OnTriggerEnter2D(Collider2D other){
		if (isWaterDrop){
			if(other.gameObject.tag == "character"){
				other.rigidbody2D.velocity = new Vector2(0,-400f);
			}
		} else if (isDart){
			if(other.gameObject.tag == "character" && GameManager.gracePeriod <= 0){
				other.rigidbody2D.velocity = new Vector2(50f,0);
				GameManager.playersHealth -= 1;
				GameManager.gracePeriod =2f;
			}
		}
		Destroy(gameObject);
	}
}


