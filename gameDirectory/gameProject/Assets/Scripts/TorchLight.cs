using System.Collections.Generic;
using UnityEngine;

public class TorchLight : MonoBehaviour {
		
	/********** LIGHT INTENSITY VARIABLES FOR A TORCHLIGHT **********/
	private float currentTime = GameManager.gameTime;
	public Light torch;
	public float upperIntensity = 0.2f;
	public float lowerIntensity= -0.2f;
	public float initialIntensity;

	
	/********** FIRE LIGHT INTENSITY SIMULATION **********/
	void Update () {

		currentTime = GameManager.gameTime;

		if ( currentTime % 2 == 0 || ( ( currentTime % 2 > 0.5 ) && (currentTime % 2 < 0.6 ) ) ) {
			torch.intensity = initialIntensity;			
		}else{ 
			torch.intensity += Random.Range(lowerIntensity, upperIntensity); 
		}
	}
}