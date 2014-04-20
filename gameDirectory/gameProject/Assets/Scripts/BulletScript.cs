using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	public int damageValue = 1;
	public Animator anim;

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "Enemy"){
			StartCoroutine (Explode());
			other.gameObject.SendMessage("EnemyDamaged", damageValue, SendMessageOptions.DontRequireReceiver);
			other.gameObject.SendMessage("GracePeriod", 2.0f, SendMessageOptions.DontRequireReceiver);
		} else if (other.gameObject.tag == "Target"){
			StartCoroutine (Explode());
			other.gameObject.SendMessage("EnemyDamaged", damageValue, SendMessageOptions.DontRequireReceiver);

		}else if (other.gameObject.tag != "character"){
			print ("BOOM");
			StartCoroutine (Explode());
		} else {
			print ("BOOM2");
		}
	}
	//void OnCollisionEnter2D(Collider2D other){Destroy(gameObject);  }
	void FixedUpdate(){
		Destroy(gameObject,4.25f);
	}

	IEnumerator Explode(){
		rigidbody2D.velocity = new Vector2(0,0);
		anim.SetBool ("exploting", true);
		yield return new WaitForSeconds (0.84f);
		Destroy (gameObject);
		anim.SetBool ("exploting", false);
	}
}

