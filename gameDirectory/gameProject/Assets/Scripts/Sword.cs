using UnityEngine;
using System.Collections;

public class Sword : MonoBehaviour {

	public int damageValue = 1;

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "Enemy"){
			other.gameObject.SendMessage("EnemyDamaged", damageValue, SendMessageOptions.DontRequireReceiver);
			other.gameObject.SendMessage("GracePeriod", 2.0f, SendMessageOptions.DontRequireReceiver);
		} else if (other.gameObject.tag == "Target" ||other.gameObject.tag == "Breakable"){
			other.gameObject.SendMessage("EnemyDamaged", damageValue, SendMessageOptions.DontRequireReceiver);
		}
	}

}
