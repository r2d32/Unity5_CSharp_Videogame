using UnityEngine;
using System.Collections;

public class Zone1Boss : MonoBehaviour {

	/********** VARIABLES FOR THE BOSS OF ZONE 1 **********/
	public Transform target;
	public Transform characterTransform;

	public float speed = 16f;
	static public bool notCloseToTarget = false;

	//Attack Variables
	public Rigidbody2D spikePrefab;
	public float dropRate = 1.0f;
	public int xVelocity = 0;
	public int yVelocity = 1;
	float coolDown = 0f;
	public bool attack = false;
	static public bool startBattleMode = false;

	public bool isFollowingCharacter = false;



	void Start () {
	}



	public void moveToTarget(){
	     notCloseToTarget = true;
	}

	/********** STAR THROWING ATTACK **********/
	void createDrop(){

		Rigidbody2D aPrefab = Instantiate (spikePrefab, transform.position, Quaternion.identity) as Rigidbody2D;
		aPrefab.rigidbody2D.velocity = new Vector2( 0f ,-10f);

		Rigidbody2D bPrefab = Instantiate (spikePrefab, transform.position, Quaternion.identity) as Rigidbody2D;
		bPrefab.rigidbody2D.velocity = new Vector2( -10f ,-10f);

		Rigidbody2D cPrefab = Instantiate (spikePrefab, transform.position, Quaternion.identity) as Rigidbody2D;
		cPrefab.rigidbody2D.velocity = new Vector2( 10f ,-10f);

	}

    /********** GO INTO SHIELDED MODE **********/

	//DEFENDLESS MODE
	void followCharacter(){
		isFollowingCharacter = true;
	}

	void resetPosition(){
		notCloseToTarget = true;
	}
		
	IEnumerator startBattle(){
		int count = 10;
		while (count>0) {
			resetPosition ();
			yield return new WaitForSeconds (0.7f);
			print ("hello" + count);
			count -=1;
		}

		// CONTINUE create and test the following steps in the boss batttle from papper.
	}

	void Update () {

		/********** MOVES THE CHARACTER TO THE TARGET SELECTED **********/
		if (notCloseToTarget) {
				
			transform.LookAt(target);
			
			if(Vector3.Distance(transform.position,target.position) >= 5f){
				
				transform.position += transform.forward*speed*Time.deltaTime;
				transform.position = new Vector3(transform.position.x,transform.position.y,-5f);
				
			} else {notCloseToTarget = false;}

			transform.rotation = Quaternion.Euler(0, 0, 0);

		} 

		/********** FOLLOWS THE CHARACTER **********/
		if (isFollowingCharacter) {
			
			transform.LookAt(characterTransform);
			
			if(Vector3.Distance(transform.position,target.position) >= 5f){
				
				transform.position += transform.forward*speed*Time.deltaTime;
				transform.position = new Vector3(transform.position.x,transform.position.y,-5f);
				
			} else {isFollowingCharacter = false;}
			
			transform.rotation = Quaternion.Euler(0, 0, 0);
			
		}

		if (startBattleMode) {
			StartCoroutine (startBattle ());
			startBattleMode = false;
		}


		if (attack){
			createDrop();
			attack = false;
		}

	
	}
}