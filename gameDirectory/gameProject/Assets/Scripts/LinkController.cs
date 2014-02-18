using UnityEngine;
using System.Collections;

public class LinkController : MonoBehaviour {
	public float maxSpeed = 4f;
	float boost = 7f;
	public static bool facingRight = true;
	public static bool flashlightOn = true;
	public Shader shaderFlashlightOff;
	public Shader shaderFlashlightOn;
	public Light flashlight;
	public static float respawnX;
	public static float respawnY;
	//Variable for grounded
	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.4f;
	public LayerMask whatIsGround;
	int jumpCount = 0;
	//Variables for ladder
	float ladderRadius = 0.06f;
	public LayerMask whatIsLadder;
    bool onLadder = false;
	public static bool dead = false;
	float time;


	public Animator anim;



	//Picking up a battery
	void OnCollisionEnter2D (Collision2D other){

		if (other.gameObject.tag == "newBattery") {
			GameManager.timeLeft = 49f;
			Destroy(other.gameObject);

		}
	}


	// Use this for initialization

	void Update(){
		print (transform.position.x);
		time = GameManager.timeLeft;

		rigidbody2D.gravityScale = (onLadder) ? 0 : 1;

		//Switch for the flashlight
		if (Input.GetKeyDown (KeyCode.F) && time > 0 ) {
			flashlightOn = !flashlightOn;
			(flashlight).enabled = flashlightOn;


		}
	
		// Setting For the flashlight
		if (time < 0) {
			(flashlight).enabled = false;
			flashlightOn = false;
		}
		if (time < 7 && time > 6.3 || time < 1.0 && time > 0.1) {
			(flashlight).enabled = (Random.Range(1,3) > 1);


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

		if (Input.GetKeyDown (KeyCode.Space) && grounded  && jumpCount < 1) {

			rigidbody2D.AddForce(new Vector2(0,700f));
			
			
		}
		//Respawn Function
		if(GameManager.playersHealth <= 0){
			dead = true;
			Respawn();
		}


	}

	void Start () {
		anim = GetComponent<Animator>();
	}


	// Update is called once per frame
	void FixedUpdate () {
		onLadder = Physics2D.OverlapCircle (groundCheck.position, ladderRadius, whatIsLadder); 		 
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround); 
		anim = GetComponent<Animator>(); 
		float move = Input.GetAxis ("Horizontal");
		float moveY = Input.GetAxis ("Vertical");

		if (grounded) {

			jumpCount  =0 ;
			rigidbody2D.velocity = new Vector2 (((Input.GetKey(KeyCode.LeftShift))? (maxSpeed + boost) : maxSpeed) * move ,
			                                    rigidbody2D.velocity.y);
		}else{
		}
		if (onLadder) {
			anim.SetFloat ( "SpeedY", moveY );
			rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, moveY * maxSpeed);

		} else { anim.SetFloat ( "SpeedY", 0 );}
		anim.SetFloat ("Speed", Mathf.Abs (move));

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

	void Respawn() {
		transform.position = new Vector2 (-25.8f, 15);
		GameManager.playersHealth = 3;
		dead = false;
	}

}

