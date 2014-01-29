using UnityEngine;
using System.Collections;

public class LinkController : MonoBehaviour {
	public float maxSpeed = 10f;
	bool facingRight = true;
	bool flashlightOn = true;
	public Shader shaderFlashlightOff;
	public Shader shaderFlashlightOn;
	float time;

	public Animator anim;
	// Use this for initialization

	void Update(){
		time = GameManager.timeLeft;

		//Switch for the flashlight
		if (Input.GetKeyDown (KeyCode.Space) && time > 0 ) {
			flashlightOn = !flashlightOn;
			((Behaviour)GetComponent ("Halo")).enabled = flashlightOn;
			renderer.material.shader = ((flashlightOn) ? shaderFlashlightOn : shaderFlashlightOff);

		}
		if (time < 0) {
			((Behaviour)GetComponent ("Halo")).enabled = false;
			renderer.material.shader = shaderFlashlightOff;
		}
	}

	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		anim = GetComponent<Animator>(); 
		float move = Input.GetAxis ("Horizontal");
		anim.SetFloat ( "Speed", Mathf.Abs(move));
		float moveY = Input.GetAxis ("Vertical");
		anim.SetFloat ( "SpeedY", moveY );
		rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);
		rigidbody2D.velocity = new Vector3 (rigidbody2D.velocity.x, moveY * maxSpeed);

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
}

