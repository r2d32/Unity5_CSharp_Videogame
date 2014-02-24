using System.Collections.Generic;
using UnityEngine;

public class TorchLight : MonoBehaviour {

	private float time = GameManager.gameTime;
	public Light torch;
	public float upperIntensity = 0.2f;
	public float lowerIntensity= -0.2f;
	public float initialIntensity;
	void Start(){
		}
	// Update is called once per frame
	void Update () {
		time = GameManager.gameTime;
		if ((time % 2) == 0 || (time % 2) == 0.5 ) {
			torch.intensity = initialIntensity;			

		}else{ torch.intensity += Random.Range(lowerIntensity, upperIntensity); }
		print("Fire"+ (time%8)+ "  Random: ");
	}
}