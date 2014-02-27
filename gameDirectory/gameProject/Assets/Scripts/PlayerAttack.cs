using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

	public Rigidbody2D bulletPrefab;
	
	public int bulletSpeed =10;
	float attackRate = .5f;
	float coolDown;

	// Update is called once per frame
	void Update () {
		if ( Input.GetButtonDown("Fire1") && Time.time >= coolDown) {
			BulletAttack();
		}
	}

	void BulletAttack(){
		Rigidbody2D bPrefab = Instantiate (bulletPrefab, transform.position, Quaternion.identity) as Rigidbody2D;
		bPrefab.rigidbody2D.velocity = new Vector2( ( (LinkController.facingRight)? bulletSpeed: -bulletSpeed),1);
		coolDown = Time.time + attackRate;
	}
}
