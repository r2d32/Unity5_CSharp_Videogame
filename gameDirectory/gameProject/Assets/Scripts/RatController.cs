using UnityEngine;
using System.Collections;

public class RatController : MonoBehaviour {
	// Reference to our GameManager Script
	public GameManager gameManager;

	//Enemies Starting/End Positions
	float startingPos;
	public Animator ratAnim;
	public int damageValue = 1;
	public int enemyLife = 3;

	bool facingRight = true;
	float endPos;
	
	//Units Enemy Moves Right
	public int unitToMove = 5;
	//Enemies Movement Speed
	public int moveSpeed = 4;
	//Moving Right or left
	bool moveRight = true; 
	static float gracePeriod = 0;

	// Use this for initialization
	void Awake () {
		startingPos = transform.position.x;
		endPos = startingPos + unitToMove;
	
	}

	void Update(){
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

		// Flicker character on grace period
		if (gracePeriod > 0) {
			this.GetComponent<SpriteRenderer> ().enabled = !this.GetComponent<SpriteRenderer> ().enabled;
			gracePeriod -= Time.deltaTime;
		} else {
			this.GetComponent<SpriteRenderer> ().enabled = true;
		}


	}

	
	//
	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "character" && GameManager.gracePeriod <= 0) {
			GameManager.playersHealth -=damageValue;
			GameManager.gracePeriod = 2.0f;
			//gameManager.SendMessage("PlayerDamaged", damageValue, SendMessageOptions.DontRequireReceiver);
			//gameManager.controller2D.SendMessage("TakenDamage", SendMessageOptions.DontRequireReceiver);
		}
	}

	//Set the animator properties
	void Start () {
		ratAnim = GetComponent<Animator>();
	}
	
	
	// Update is called once per frame
	void FixedUpdate () {
		ratAnim = GetComponent<Animator>(); 
		float move = rigidbody2D.velocity.x;
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
