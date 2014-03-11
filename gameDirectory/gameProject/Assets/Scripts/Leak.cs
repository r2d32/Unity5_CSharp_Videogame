using UnityEngine;
using System.Collections;

public class Leak : MonoBehaviour {

	public Rigidbody2D waterDropPrefab;
	public float dropRate = 1.0f;
	float coolDown = 0f;
	void Update () {
		if (Time.time >= coolDown) createDrop();
	}
	void createDrop(){

		Rigidbody2D bPrefab = Instantiate (waterDropPrefab, transform.position, Quaternion.identity) as Rigidbody2D;
		bPrefab.rigidbody2D.velocity = new Vector2( 0 ,1);
		coolDown = Time.time + dropRate; 


	}
}
