using UnityEngine;
using System.Collections;

public class objectThrower : MonoBehaviour {

	public Rigidbody2D waterDropPrefab;
	public float dropRate = 1.0f;
	public int xVelocity = 0;
	public int yVelocity = 1;
	float coolDown = 0f;
	void Update () {
		if (Time.time >= coolDown) createDrop();
	}
	void createDrop(){

		Rigidbody2D bPrefab = Instantiate (waterDropPrefab, transform.position, Quaternion.identity) as Rigidbody2D;
		bPrefab.rigidbody2D.velocity = new Vector2( xVelocity ,yVelocity);
		coolDown = Time.time + dropRate; 


	}
}
