using UnityEngine;
using System.Collections;

public class Butterfly_npc : MonoBehaviour {
	
		
	public Transform target;//set target from inspector instead of looking in Update
	public float speed = 10f;
	public static bool following = false;

		
	
	// Update is called once per frame
	void Update () {
		if (following) {

			transform.LookAt(target);
			
			if(Vector3.Distance(transform.position,target.position) >= 4f){
				
				transform.position += transform.forward*speed*Time.deltaTime;
				transform.position = new Vector3(transform.position.x,transform.position.y,-5f);

			}
			transform.rotation = Quaternion.Euler(0, 0, 0);

		}
	
	}
}
