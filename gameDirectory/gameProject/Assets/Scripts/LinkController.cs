using UnityEngine;
using System.Collections;

public class LinkController : MonoBehaviour {
	public float maxSpeed = 10f;
	bool facingRight = true;

	public Animator anim;

	// Use this for initialization
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

