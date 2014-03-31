﻿using UnityEngine;
using System.Collections;

public class Zone : MonoBehaviour {

	public int zoneNumber = 1;
	public bool zoneBoss = false;
	public Light mainLight;

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "character" && zoneNumber == 1 && !zoneBoss) {
			Butterfly_npc.following = !Butterfly_npc.following;
			mainLight.enabled = !mainLight.enabled;
			Zone1Boss.notCloseToTarget = true;
		} else if (other.gameObject.tag == "character" && zoneNumber == 1 && zoneBoss) {
			Zone1Boss.startBattleMode = true;
		}
	}
}
