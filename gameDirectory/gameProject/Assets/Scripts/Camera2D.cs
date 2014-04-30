using UnityEngine;
using System.Collections;

public class Camera2D : MonoBehaviour {

    public float dampTime = 0.15f;
    private Vector3 velocity = Vector3.zero;
    public Transform target;
    public float cameraHeight = 0f;
    float verticalLook = 0f;

	/********** SIMPLE SCRIPT FOR CAMERA **********/
    void Update () 
    {
        /********** CHARACTER LOOKING UP AND DOWN **********/
        if (LinkController.grounded && ( Input.GetAxis ("Vertical") != 0f)){
            verticalLook = (Input.GetAxis ("Vertical") > 0)? -0.18f: 0.18f;       
        } else {
            verticalLook = 0f;
        }

        /********** CHARACTER FOLLOWING **********/
        if (target)
        {
            Vector3 point = camera.WorldToViewportPoint(target.position);
            Vector3 delta = target.position - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f + cameraHeight + verticalLook, point.z));
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }	
    }
}
