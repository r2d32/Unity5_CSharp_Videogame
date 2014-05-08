using UnityEngine;
using System.Collections;

public class Breakable : MonoBehaviour {
    public Animator anim;
    public int durability;
    public AudioSource knockSound;
    public AudioClip hitSound;
    public bool sound = false;

    void Example() {
        if (rigidbody2D.angularVelocity > 5f){
            //print(rigidbody2D.angularVelocity + "BOX");
            //if(sound)
                //knockSound.Play();
        } else if (rigidbody2D.angularVelocity == 0f){
                       // if(sound)
            //knockSound.Stop();
        }
    }
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
    void OnCollisionStay2D(Collision2D other){
        //if(other.relativeVelocity.magnitude > 21f)
                        //print(other.relativeVelocity.magnitude + "BOX");
  
    }
    void OnCollisionEnter2D(Collision2D other){

        if(other.relativeVelocity.magnitude > 6f){
            float collisionStrength =other.relativeVelocity.magnitude/10f;
            if(other.collider.tag == "character"){
            if(sound) 
                knockSound.PlayOneShot(hitSound,0.75f *collisionStrength);
           // print(other.relativeVelocity.magnitude + "BOX");
            }
        }
    }
    // Update is called once per frame
    void Update () {
        Example();
        if (durability == 0) {
            anim.enabled = true;
            collider2D.enabled = false;
            Destroy(gameObject,1.25f);
        }
    }
}
