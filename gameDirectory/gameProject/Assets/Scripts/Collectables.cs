using UnityEngine;
using System.Collections;

public class Collectables : MonoBehaviour {

	//********** INFO ABOUT THE PICK OBJECT **********//
	public bool itemCoins;
	public bool itemRocks;
	public bool specialItem;
	public Texture2D item;
	public int numOfCollectables;

	//********** ADD ITEM TO CHARACTER **********//
	void OnTriggerEnter2D(Collider2D other){
		
		if (other.gameObject.tag == "character") {

			if(itemCoins){
				Destroy(gameObject);
				for(int i = 0; i < numOfCollectables; i++){
					LinkController.numOfCoins += 1;
				}
			} else if (specialItem){
				GameManager.characterKeyItems.Add(item);
				Destroy(gameObject);
			}else if(itemRocks){
				Destroy(gameObject);
				LinkController.numOfRocks += numOfCollectables;
			}

		}
	}
}
