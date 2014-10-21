using UnityEngine;
using System.Collections;

public class LoadScenesASync : MonoBehaviour {

	// Use this for initialization
	public Color fadeColor = Color.white;
	public float fadeDuration = 2f;
	public float minFadeDelay = 2f;
	
	public string levelToLoadAsync;
	public string levelToStartNext;
	
	private AsyncOperation loadingLevel;
	private float elapsedTime;
	
	void Start () {
		
		loadingLevel = Application.LoadLevelAdditiveAsync(levelToLoadAsync);
	}
	
	// Update is called once per frame
	void Update () {
		
		elapsedTime += Time.deltaTime;
		if(loadingLevel.isDone)
		{
			Debug.Log("Done loading level. Elapsed time: " + elapsedTime);
			if(elapsedTime >= minFadeDelay)
				CameraFade.StartAlphaFade( fadeColor, false, fadeDuration, 0, () => { Application.LoadLevel(levelToStartNext); } );
		}
	}
}
