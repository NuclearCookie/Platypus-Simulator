using UnityEngine;
using System.Collections;

public class FadeOutToNextLevel : MonoBehaviour
{
	public Color fadeColor = Color.white;
	public float fadeDuration = 2f;
	public float fadeDelay = 2f;
	public int levelName;
	public bool bCanSkip = false;
	public bool infinite = false;
	// Use this for initialization
	void Start ()
	{
		if(!infinite)
		{
			CameraFade.StartAlphaFade( fadeColor, false, fadeDuration, fadeDelay, () => { Application.LoadLevel(levelName); } );
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(bCanSkip && Input.anyKey)
		{
			if(infinite)
			{
				Application.LoadLevel(levelName);
			}
			else
			{
				CameraFade.FinishFading();
			}
		}

	}
}
