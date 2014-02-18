using UnityEngine;
using System.Collections;

public class LevelSelect : MonoBehaviour {


	public int x = 0;
	public int y= 0;
	int sw = Screen.width;
	int sh = Screen.height;

	void OnGUI(){
		//LEVEL 1 Button
		if(GUI.Button (new Rect(x,y,sw*.5f,sh*.5f),"LEVEL #1")){
			Application.LoadLevel("Scene1");

		}
		if(PlayerPrefs.GetInt("levelUnlock", 0)>=2){
			if(GUI.Button (new Rect(sw*.5f,y,sw*.5f,sh*.5f),"LEVEL #2")){
				Application.LoadLevel("Scene2");
			
			}
		} else {
			GUI.Box (new Rect(sw*.5f,y,sw*.5f,sh*.5f),"LOCKED"+"\n"+"LEVEL #2");
		}
	}
}
