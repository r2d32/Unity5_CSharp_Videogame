using UnityEngine;
using System.Collections;

public class Breakable : MonoBehaviour {
    public Animator anim;
    public int durability;


   	// Use this for initialization
    void Start () {
        anim.enabled = false;
    
    }
    void EnemyDamaged(int damage){
        if (durability > 0)
            durability --;
        if (durability <= 0) {
            durability = 0;
        }
    }

    // Update is called once per frame
    void Update () {
        if (durability == 0) {
            anim.enabled = true;
            collider2D.enabled = false;
            Destroy(gameObject,1.25f);
        }
    }
}
