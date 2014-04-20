using UnityEngine;
using System.Collections;

public class Zone1Boss : MonoBehaviour {

	/********** VARIABLES FOR THE BOSS OF ZONE 1 **********/
	public Transform target;
	public Transform characterTransform;
	public Animator anim; 
	public float speed = 16f;
	static public bool notCloseToTarget = false;
	public float gracePeriod = 0f;
	public Light bossLight;
	public GameObject[] objectsToDestroyOnDeath;
	public AudioSource[] musics; 

	//Attack Variables
	public Rigidbody2D spikePrefab;
	public Color attackColor;
	public Color defendlessColor;
	public float dropRate = 1.0f;
	public int xVelocity = 0;
	public int enemyLife = 1;
	public int yVelocity = 1;
	bool defensless = false;
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
	void starAttack(){

		Rigidbody2D aPrefab = Instantiate (spikePrefab, transform.position, Quaternion.identity) as Rigidbody2D;
		aPrefab.rigidbody2D.velocity = new Vector2( 0f ,-10f);

		Rigidbody2D bPrefab = Instantiate (spikePrefab, transform.position, Quaternion.identity) as Rigidbody2D;
		bPrefab.rigidbody2D.velocity = new Vector2( -10f ,-10f);

		Rigidbody2D cPrefab = Instantiate (spikePrefab, transform.position, Quaternion.identity) as Rigidbody2D;
		cPrefab.rigidbody2D.velocity = new Vector2( 10f ,-10f);

	}

    /********** GO INTO SHIELDED MODE **********/

	void followCharacter(){
		isFollowingCharacter = true;
	}

	void resetPosition(){
		notCloseToTarget = true;
	}
	/********** **********/
	void EnemyDamaged(int damage){
		if (enemyLife > 0 && defensless)
			enemyLife --;
		if (enemyLife <= 0) {
			enemyLife = 0;
			StartCoroutine( Die());
		}
	}
	IEnumerator Die(){
		anim.SetBool ("crazy", true);
		yield return new WaitForSeconds (2f);
		anim.SetBool ("crazy", false);
		anim.SetBool ("dead", true);
		yield return new WaitForSeconds (4f);
		Destroy(gameObject);
		for (int i = 0; i < objectsToDestroyOnDeath.Length; i++) {
			Destroy(objectsToDestroyOnDeath[i].gameObject);
		}
	}

	/********** COLLLIDER ATTACK **********/
	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "character" && GameManager.gracePeriod <= 0) {
			GameManager.playersHealth -=1;
			GameManager.gracePeriod = 2.0f;
		}
	}

	IEnumerator startBattle(){
		int numOfShots = 3;
		float originalSpeed = speed;

		while(enemyLife > 0){
			speed = originalSpeed + (4 - enemyLife);
			notCloseToTarget = true;
			yield return new WaitForSeconds (1f);
			defensless = true;
			notCloseToTarget = false;
			bossLight.color = defendlessColor;
			yield return new WaitForSeconds(2f);
			if(enemyLife > 0){
				defensless = false;
				bossLight.color = attackColor;

				for(int i = 0; i < numOfShots; i++ ){
					this.collider2D.enabled = false;
					starAttack();
					yield return new WaitForSeconds (0.7f);
				}
				this.collider2D.enabled = true;
				bossLight.color = attackColor;
				isFollowingCharacter = true;
				anim.SetBool ("crazy", true);
				yield return new WaitForSeconds ( 5f );
				isFollowingCharacter = false;
				anim.SetBool ("crazy", false);
			}
		}
	}
	void GracePeriod(float passedTime){
		gracePeriod = passedTime;
	}
	void Update () {

		/********** MOVES THE CHARACTER TO THE TARGET SELECTED **********/
		if (notCloseToTarget) {
				
			transform.LookAt(target);
			transform.position += transform.forward*speed*Time.deltaTime;
			transform.position = new Vector3(transform.position.x,transform.position.y,0f);
			transform.rotation = Quaternion.Euler(0, 0, 0);

		} 

		/********** FOLLOWS THE CHARACTER **********/
		if (isFollowingCharacter) {
			
			transform.LookAt(characterTransform);
			transform.position += transform.forward*speed*Time.deltaTime;
			transform.position = new Vector3(transform.position.x,transform.position.y,0f);
			transform.rotation = Quaternion.Euler(0, 0, 0);
			
		}

		/********** NPC's GRACE PERIOD **********/ 
		if (gracePeriod > 0) {
			this.GetComponent<SpriteRenderer> ().enabled = !this.GetComponent<SpriteRenderer> ().enabled;
			gracePeriod -= Time.deltaTime;
		} else {
			this.GetComponent<SpriteRenderer> ().enabled = true;
		}

		if (startBattleMode) {
			musics[0].enabled = false;
			musics[1].enabled = true;

			StartCoroutine (startBattle ());
			startBattleMode = false;
		}

	
	}
}