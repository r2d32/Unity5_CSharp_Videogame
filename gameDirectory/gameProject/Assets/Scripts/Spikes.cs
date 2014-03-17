﻿using UnityEngine;
using System.Collections;
using System;

public class Spikes : MonoBehaviour {

	public GameManager gameManager;
	
	/********** NPC's VARIABLES **********/
	public bool isDynamicSpike = false;
	bool facingRight = true;
	bool changeYposition = false;
	bool moveRight = true; 
	float yStartingPos;
	float yEndPos;
	float endPos;
	float startingPos;
	public float unitToMove = 5;
	public float yUnitToMove = 1.5f;
	public float moveSpeed = 4;
	public float yMoveSpeed = 4;
	public float tolerance = 0.0f;
	string currentDirection = "right";
	string[] directions = { "right",
		"down",
		"left",
		"up"};

	/********** INITIALIZATION ***********/
	void Awake () {
		startingPos = this.transform.position.x;
		yStartingPos = this.transform.position.y;

	}

	void Update(){
		endPos = startingPos + unitToMove;
		yEndPos = yStartingPos - yUnitToMove;
		if (isDynamicSpike) {
			switch (Array.IndexOf(directions, currentDirection))
			{
			case 0: //move right
				rigidbody2D.velocity = new Vector2 (moveSpeed, 0);
				if (transform.position.x >= (endPos - tolerance))
				    currentDirection = "down";
				break;
			case 1: //move down
				rigidbody2D.velocity = new Vector2 (0, -yMoveSpeed);
				if (transform.position.y <= (yEndPos + tolerance))
				    currentDirection = "left";
				break;
			case 2: //move left
				rigidbody2D.velocity = new Vector2 (-moveSpeed, 0);
				if (transform.position.x <= (startingPos + tolerance))
				    currentDirection = "up";
				break;
			case 3: //move up
				rigidbody2D.velocity = new Vector2 (0, yMoveSpeed);
				if (transform.position.y >= (yStartingPos - tolerance))
				    currentDirection = "right";
				break;
			}
		}
	}

	/********** SPIKE's COLLIDER DAMAGE **********/		
	IEnumerator OnTriggerEnter2D(Collider2D other){
			
		if (other.gameObject.tag == "character") {
			LinkController.dead = true;
			yield return new WaitForSeconds(3);
			GameManager.playersHealth = 0 ;
		}
	}
}
