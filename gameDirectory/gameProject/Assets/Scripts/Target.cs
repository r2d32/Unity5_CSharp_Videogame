using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour {

	public int targetHitsLeft;
	public SpriteRenderer targetStatus;
	public Sprite[] targetPics;


	
	// Update is called once per frame
	void Update () {
	
	}
	void EnemyDamaged(int damage){
		if (targetHitsLeft > 0)
			targetHitsLeft --;
		if (targetHitsLeft <= 0) {
			targetHitsLeft = 0;
		}
		targetStatus.sprite = targetPics [targetHitsLeft];
	}
}
