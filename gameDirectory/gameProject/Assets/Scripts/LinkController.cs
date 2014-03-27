using UnityEngine;
using System.Collections;
using System;
public class LinkController : MonoBehaviour {

	public float maxSpeed = 4f;
	float boost = 4f;
	public static bool facingRight = true;
	public static bool flashlightOn = false;
	static bool characterRunning = false;
	static bool justLanded;
	public static bool characterHasFlashlight = false;
	public Shader shaderFlashlightOff;
	public Shader shaderFlashlightOn;
	public Light flashlight;
	public static float respawnX = -188.7f;
	public static float respawnY = 8.79f;
	public static float respawnZ = -1f;
	public static int numOfCoins = 0;
	public static int numOfRocks = 0;
	//Variable for grounded
	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.4f;
	public LayerMask whatIsGround;
	int jumpCount = 0;
	public int jumpsAllowed = 2;
	//Variables for ladder
	float ladderRadius = 0.06f;
	public LayerMask whatIsLadder;
    bool onLadder = false;
	public static bool dead = false;
	float time;
	//Variables for walls
	public Transform wallCheckL;
	float wallRadius;
	bool touchingL = false;	
	public Animator anim;
	//Sound variables
	public AudioSource jumpSound;
	public AudioClip landSound;
	public AudioClip walkSound;





	void OnCollisionEnter2D (Collision2D other){

		//Picking up a battery
		if (other.gameObject.tag == "newBattery") {
			GameManager.batteryTimeLeft = 49f;
			Destroy(other.gameObject);

		}
		//Landing Sound
		if (other.relativeVelocity.magnitude > 16 && other.gameObject.tag == "Ground") {
			print ("Sound" + other.relativeVelocity.magnitude );
			AudioSource.PlayClipAtPoint(landSound, transform.position);
		}
			
	}


	// Use this for initialization


	void Update(){
		anim.SetBool ("dead", dead);
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround); 
	    touchingL = Physics2D.OverlapCircle (wallCheckL.position, groundRadius, whatIsGround); 
		time = GameManager.batteryTimeLeft;

		rigidbody2D.gravityScale = (onLadder) ? 0 : 1;

		//Switch for the flashlight
		if (characterHasFlashlight && Input.GetButtonDown("Light") && time > 0 ) {
			flashlightOn = !flashlightOn;
			(flashlight).enabled = flashlightOn;


		} 

	
		// Setting For the flashlight
		if (time < 0) {
			(flashlight).enabled = false;
			flashlightOn = false;
		}
		if (time < 7 && time > 6.3 || time < 1.0 && time > 0.1) {
			(flashlight).enabled = (UnityEngine.Random.Range(1,3) > 1);


		}
		if (time < 6 && time > 5.6 ) {(flashlight).enabled = true;}

		if (time < 0) {
			(flashlight).enabled = false;
		}

		// Flicker character on grace period
		if (GameManager.gracePeriod > 0) {
			this.GetComponent<SpriteRenderer> ().enabled = !this.GetComponent<SpriteRenderer> ().enabled;
		} else {
			this.GetComponent<SpriteRenderer> ().enabled = true;
		}
		// Character Jump
		if (Input.GetButtonDown("Jump") && ( grounded || jumpCount < jumpsAllowed) && !dead) {


			jumpSound.Play();
			jumpCount = (grounded)?   0:jumpCount;   

			if(jumpCount < 1){

				rigidbody2D.AddForce(new Vector2(0,830f));
			}else{
				rigidbody2D.AddForce(new Vector2(0,400f));
			}
			jumpCount =jumpCount +1;
		
		} else { 
			justLanded = true;
		}

		//Respawn Function
		if(GameManager.playersHealth <= 0 ){
			dead = true;

			StartCoroutine( "Respawn");
		}

	}

	void Start () {
		anim = GetComponent<Animator>();
	}


	// Update is called once per frame
	void FixedUpdate () {
		onLadder = Physics2D.OverlapCircle (groundCheck.position, ladderRadius, whatIsLadder); 		 
		anim = GetComponent<Animator>(); 
		float move = Input.GetAxis ("Horizontal");
		float moveY = Input.GetAxis ("Vertical");

		if (!dead) {

			if (grounded) {
	
				rigidbody2D.velocity = new Vector2 (((Input.GetButton("Run") || (Input.GetAxis("Run") > 0.5f))? (maxSpeed + boost) : maxSpeed) * move ,
			   	                                    rigidbody2D.velocity.y);

			}
			if (onLadder) {
				anim.SetFloat ( "SpeedY", moveY );
				rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, moveY * maxSpeed);

			} else { 
				anim.SetFloat ( "SpeedY", 0 );
			}
			if (!grounded && !onLadder) {
				rigidbody2D.velocity = new Vector2 (((Input.GetButton("Run") || (Input.GetAxis("Run") > 0.5f))? (maxSpeed + boost) : maxSpeed) * move ,
				                                    rigidbody2D.velocity.y);

			} 
			characterRunning = (( move < -0.9f || move > 0.9f) && (Input.GetButton ("Run") || (Input.GetAxis ("Run") > 0.5f)));

			anim.SetFloat("Speed", Mathf.Abs (move));
			anim.SetBool ("running", characterRunning);
			anim.SetBool ("jumping", !(grounded));
			anim.SetBool ("dead", dead);
			anim.SetBool ("onLadder", onLadder);
			anim.SetBool ("onLadderMoving", (onLadder && ( Mathf.Abs (move) !=0 || moveY != 0 )));
			anim.SetBool ("throw", Input.GetButtonDown ("Fire1"));


			if (move > 0 &&!facingRight) 
				Flip ();
			else if (move < 0 && facingRight)
				Flip ();
		}
	}
	void Flip() {

		facingRight = !facingRight;
		Vector4 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;

	}

	IEnumerator Respawn() {
		if (dead){
			GameManager.playersHealth = 3;
			yield return new WaitForSeconds(3f);
			dead = false;
			transform.position = new Vector3 (respawnX, respawnY, respawnZ);
			GameManager.gracePeriod = 2f;
		}
	}

}