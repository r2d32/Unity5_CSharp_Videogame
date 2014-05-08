using UnityEngine;
using System.Collections;

public class CameraFade : MonoBehaviour
{
    //====================================================================================================
    // Member Variables
    //====================================================================================================
    public float StartAlpha = 1.0f; // The transparency value to start fading from
    public float EndAlpha = 0.0f; // The transparency value to end fading at
    public float FadingSpeed = 1.0f; // The speed of the effect
    public AudioSource respawnSound;
    bool playedRespawnSound = false;
    
    private float Timer = 0.0f; // The time passed since fading was enabled
    public static bool FadingOn = false; // Controls whether to fade or not
    public Material mater;
    public bool endOfDemo = false;
    bool midway = false;
    bool middleWait = false;
    
    //====================================================================================================
    // Custom Functions
    //====================================================================================================
    
    // Use this function to control fading using another script
    // i.e.
    // Fading fadingScript = fadingObject.GetComponent<Fading>();

    // fadingScript.Fade(true);
    public void Fade(bool fade){
        FadingOn = fade;
    }
    
    
    //====================================================================================================
    // Unity Functions
    //====================================================================================================
    void LateUpdate(){
        // Don't do anything if we are not fading
        if (!FadingOn || middleWait){
            
            Timer = 0.0f;
            StartAlpha = 0f;
            EndAlpha = 1f;
            return;
        }
        // Increase the timer by the amount of time passed since the last frame
        Timer += Time.deltaTime;
        
        
        // Change the material's color, keeping RGB intact and interpolating alpha between
        // StartAlpha and EndAlpha
        mater.color = new Color
            (
                mater.color.r,
                mater.color.g,
                mater.color.b,
                Mathf.Lerp(StartAlpha, EndAlpha, Timer * FadingSpeed)
                );
        
        // Done fading
        if (mater.color.a == EndAlpha){
            // Stop fading and reset timer
            Timer = 0.0f;
            if (midway){
                FadingOn = false;
                midway =false;
            } else {
                float newEnd = StartAlpha;
                StartAlpha = EndAlpha;
                EndAlpha = newEnd;
                midway =true;
                if(!playedRespawnSound){
                    respawnSound.Play();
                }   
            }
            // Do whatever you need to do
            // i.e.: transition or destroy this object
        }
    }
}