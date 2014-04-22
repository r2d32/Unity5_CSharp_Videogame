using UnityEngine;
using System.Collections;

public class SineMovement : MonoBehaviour {
        public float CurveSpeed = 5;
        public float MoveSpeed = 1;
        
        float fTime = 0;
        Vector3 vLastPos = Vector3.zero;
        
        // Use this for initialization
        void Start () 
        {
                vLastPos = transform.position;
        }
        
        // Update is called once per frame
        void Update () 
        {
                vLastPos = transform.position;
                
                fTime += Time.deltaTime * CurveSpeed;
                
                Vector3 vSin = new Vector3(Mathf.Sin(fTime), -Mathf.Sin(fTime), 0);
                Vector3 vLin = new Vector3(MoveSpeed, MoveSpeed, 0);
                
                transform.position += (vSin + vLin) * Time.deltaTime;
                
                Debug.DrawLine(vLastPos, transform.position, Color.green, 100);
    }
}