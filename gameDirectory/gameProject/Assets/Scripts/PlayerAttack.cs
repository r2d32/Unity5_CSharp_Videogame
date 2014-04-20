using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

	public Rigidbody2D bulletPrefab;
	public Transform origin;
	
	public int bulletSpeed =10;
	float attackRate = 0.5f;
	float coolDown;
	public Animator anim;

	// Update is called once per frame
	void Update () {
		if ( Input.GetButtonDown("Fire1") && Time.time >= coolDown) {
			StartCoroutine (BulletAttack());
			anim.SetBool ("throw", true);
			LinkController.numOfRocks -=1;

		} else{
			anim.SetBool ("throw", false);
		}
	}
	IEnumerator BulletAttack(){
		yield return new WaitForSeconds (0.2f);
		Rigidbody2D bPrefab = Instantiate (bulletPrefab, origin.position, Quaternion.identity) as Rigidbody2D;
		bPrefab.rigidbody2D.velocity = new Vector2( ( (LinkController.facingRight)? bulletSpeed: -bulletSpeed),1);
		coolDown = Time.time + attackRate;
	}
}
