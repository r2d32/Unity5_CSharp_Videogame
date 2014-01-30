using UnityEngine;

using System.Collections;



public class TrailSwitch : MonoBehaviour {
	
	
	
	public KeyCode UserKey =  KeyCode.T;
	
	TrailRenderer Trail;
	
	bool TrailOn;
	
	
	
	
	
	// Use this for initialization
	
	void Start () {
		
		
		
		Trail = gameObject.GetComponent<TrailRenderer>();
		
		
		
	}
	
	
	
	// Update is called once per frame
	
	void Update () {
		
		
		
		if(Input.GetKey(UserKey)&& TrailOn){
			
			
			
			Trail.time = 0f;
			
			TrailOn = false;
			
			
			
		}else if(Input.GetKey(UserKey) && !TrailOn){
			
			
			
			Trail.time = 1000f;
			
			TrailOn = true;
			
			
			
		}
		
		
		
	}
	
}