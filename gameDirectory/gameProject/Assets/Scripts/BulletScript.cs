using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	public int damageValue = 1;
	public Animator anim;
    public AudioClip explosion;
	void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Enemy"|| other.gameObject.tag == "Boss" ){
			StartCoroutine (Explode());
			other.gameObject.SendMessage("EnemyDamaged", damageValue, SendMessageOptions.DontRequireReceiver);
			other.gameObject.SendMessage("GracePeriod", 2.0f, SendMessageOptions.DontRequireReceiver);
		} else if (other.gameObject.tag == "Target"){
			StartCoroutine (Explode());
			other.gameObject.SendMessage("EnemyDamaged", damageValue, SendMessageOptions.DontRequireReceiver);

        }else if (other.gameObject.tag != "character" && other.gameObject.tag != "Untagged" && other.gameObject.tag != "Checkpoint"){
			StartCoroutine (Explode());
		} else {
		}
	}
	void FixedUpdate(){
		Destroy(gameObject,4.25f);
	}

	IEnumerator Explode(){
		rigidbody2D.velocity = new Vector2(0,0);
		anim.SetBool ("exploting", true);
        AudioSource.PlayClipAtPoint(explosion, transform.position,2f);
		yield return new WaitForSeconds (0.84f);
		Destroy (gameObject);
		anim.SetBool ("exploting", false);
	}
}

