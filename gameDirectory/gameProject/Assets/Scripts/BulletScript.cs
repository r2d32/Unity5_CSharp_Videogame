using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	public int damageValue = 1;

	void OnTriggerEnter2D(Collider2D other){
		//print ("HIT");
		if(other.gameObject.tag == "Enemy"){
			Destroy(gameObject);
			other.gameObject.SendMessage("EnemyDamaged", damageValue, SendMessageOptions.DontRequireReceiver);
			other.gameObject.SendMessage("GracePeriod", 2.0f, SendMessageOptions.DontRequireReceiver);
		}
	}
	void FixedUpdate(){
		Destroy(gameObject,1.25f);
	}
}

