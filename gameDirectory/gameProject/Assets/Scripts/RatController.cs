using UnityEngine;
using System.Collections;

public class RatController : MonoBehaviour {

	public GameManager gameManager;

	/********** NPC's VARIABLES **********/
	float startingPos;
	public Animator ratAnim;
	public int damageValue = 1;
	public int enemyLife = 3;
	bool facingRight = true;
	float endPos;
	public int unitToMove = 5;
	public int moveSpeed = 4;
	bool moveRight = true; 
	static float gracePeriod = 0;
	public Transform playersTransform;
	bool onCyclicMovement;
	float move;

	/********** INITIALIZATION ***********/
	void Awake () {
		startingPos = transform.position.x;
		endPos = startingPos + unitToMove;
	 
	}

	void Update(){

		/********** FOLLOW CHARACTER IF IS CLOSE **********/
		transform.LookAt(playersTransform);
		
		if(Vector3.Distance(transform.position,playersTransform.position) < 7f){
			onCyclicMovement = false;
			
			transform.position += transform.forward*(moveSpeed * 2)*Time.deltaTime;
			transform.position = new Vector3(transform.position.x,transform.position.y,-5f);

			move = (transform.position.x < playersTransform.position.x )? 1f : -1f; 
			
		}else {
			onCyclicMovement = true;
		}
		transform.rotation = Quaternion.Euler(0, 0, 0);

		if (onCyclicMovement){
			if(moveRight){
				rigidbody2D.velocity = new Vector2 (moveSpeed, rigidbody2D.velocity.y);
			}
			if (transform.position.x >= endPos) {
				moveRight = false;
			}
			if(!moveRight){
				rigidbody2D.velocity = new Vector2 (-moveSpeed, rigidbody2D.velocity.y);
			}
			if (transform.position.x <= startingPos) {
				moveRight = true;

			}
		}

		/********** NPC's GRACE PERIOD **********/ 
		if (gracePeriod > 0) {
			this.GetComponent<SpriteRenderer> ().enabled = !this.GetComponent<SpriteRenderer> ().enabled;
			gracePeriod -= Time.deltaTime;
		} else {
			this.GetComponent<SpriteRenderer> ().enabled = true;
		}



	}

	
	/********** COLLLIDER ATTACK **********/
	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "character" && GameManager.gracePeriod <= 0) {
			GameManager.playersHealth -=damageValue;
			GameManager.gracePeriod = 2.0f;
		}
	}

	//Set the animator properties
	void Start () {
		ratAnim = GetComponent<Animator>();
	}
	
	
	/********** NPC's MOVEMENT **********/ 
	void FixedUpdate () {
		ratAnim = GetComponent<Animator>(); 
		if (onCyclicMovement)
			move = rigidbody2D.velocity.x;
		ratAnim.SetFloat ( "S", Mathf.Abs(move));

		if (move > 0 &&!facingRight) 
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();
	}

	void Flip() {
		
		facingRight = !facingRight;
		Vector4 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
		
	}

	void GracePeriod(float passedTime){
		gracePeriod = passedTime;
	}

	void EnemyDamaged(int damage){
		if (enemyLife > 0)
			enemyLife --;
		if (enemyLife <= 0) {
			enemyLife = 0;
			Destroy(gameObject);
		}
	}

}
