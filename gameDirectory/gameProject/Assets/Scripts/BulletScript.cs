using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	public int damageValue = 1;

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "Enemy"){
			Destroy(gameObject);
			other.gameObject.SendMessage("EnemyDamaged", damageValue, SendMessageOptions.DontRequireReceiver);
			other.gameObject.SendMessage("GracePeriod", 2.0f, SendMessageOptions.DontRequireReceiver);
		} else if (other.gameObject.tag != "character"){
			Destroy(gameObject);
		}
	}
	//void OnCollisionEnter2D(Collider2D other){Destroy(gameObject);  }
	void FixedUpdate(){
		Destroy(gameObject,1.25f);
	}
}

