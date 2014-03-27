using UnityEngine;
using System.Collections;

public class Zone : MonoBehaviour {

	public int zoneNumber = 1;
	public Light mainLight;

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "character" && zoneNumber == 1) {
			Butterfly_npc.following = !Butterfly_npc.following;
			mainLight.enabled = !mainLight.enabled;
		}
	}
}
