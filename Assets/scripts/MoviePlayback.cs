using UnityEngine;  
using System.Collections;  
   
[RequireComponent (typeof (AudioSource))]  
  
public class MoviePlayback : MonoBehaviour
{
#if UNITY_STANDALONE
    //the AudioSource  
    private AudioSource movieAS;  
    //the movie name inside the resources folder  
    
    public MovieTexture movie; 
  
    void Awake()  
    {  
        //get the attached AudioSource  
        movieAS = this.GetComponent<AudioSource>();   
        
        //set the AudioSource clip to be the same as the movie texture audio clip  
        movieAS.clip = movie.audioClip;  
      
        /*//anamorphic fullscreen  
        videoGUItex.pixelInset = new Rect(Screen.currentResolution.width/2, -Screen.currentResolution.height/2,0,0);  */
    }  
  
    //On Script Start  
    void Start()  
    {  
        //renderer.material.mainTexture.Play();
        //Plays the movie  
        movie.Play();  
        //plays the audio from the movie  
        movieAS.Play();  
    }  
#endif
}  