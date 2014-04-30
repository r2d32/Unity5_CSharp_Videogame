using UnityEngine;
using System.Collections;

using UnityEngine;

public class SineMovement : MonoBehaviour{



        public float CurveSpeed = 0.5f;
        public float MoveSpeed = 0.1f;
        public float frequency = 0.5f;
        public float wavelength = 0.5f;
        bool goingRight = true;
        float startingPos;
        float endPos;
        float unitToMove = 5f;
        float xchange;
        Transform pos;
        bool moveRight;
        
        float fTime = 100f;
        public Transform initialPos;
        // Use this for initialization
        void Start () 
        {

                startingPos = transform.position.x;
                endPos = startingPos + unitToMove;
        }
        
        // Update is called once per frame
        void Update ()  
        {


                if(moveRight){
                        xchange= 0.1f; 

                }if (transform.position.x >= endPos) {
                        moveRight = false;
                }
                if(!moveRight){
                        xchange = -0.1f;
                }
                if (transform.position.x <= startingPos) {
                        moveRight = true;
                        
                }


                Vector3 vSin = new Vector3(xchange , Mathf.Sin(2 * Mathf.PI * Time.time * frequency) * wavelength, -0);
                
                transform.position += (vSin ) ;
                
        }
}