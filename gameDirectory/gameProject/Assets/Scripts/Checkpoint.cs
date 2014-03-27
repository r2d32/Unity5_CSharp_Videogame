using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {
	public Animator checkpointAnim;
	public Sprite activeCheclpoint;
	public SpriteRenderer checkpointRenderer;
	bool activated = false;
	public AudioSource activateSound;

	void OnTriggerEnter2D(Collider2D other){
		
		if (other.gameObject.tag == "character") {
			LinkController.respawnX = this.transform.position.x;
			LinkController.respawnY = this.transform.position.y;
			checkpointAnim.SetBool ("active", true);
			checkpointRenderer.sprite = activeCheclpoint;

			//CHECKPOINT SOUND
			if (!activated)
				activateSound.PlayOneShot(activateSound.clip);
			activated = true;

		}
	}
	//Set the animator properties
	void Start () {
		checkpointAnim = GetComponent<Animator>();
	}
}
