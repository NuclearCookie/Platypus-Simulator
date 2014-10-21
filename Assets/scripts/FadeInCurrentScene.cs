using UnityEngine;
using System.Collections;

public class FadeInCurrentScene : MonoBehaviour {
	
	public Color fadeColor = Color.white;
	public float fadeDuration = 2f;
	public float fadeDelay = 0f;
	
	// Use this for initialization
	void Start () {
		CameraFade.StartAlphaFade( fadeColor, true, fadeDuration, fadeDelay, null );
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
