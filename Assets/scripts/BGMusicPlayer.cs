using UnityEngine;
using System.Collections;

public class BGMusicPlayer : MonoBehaviour {

	
	public AudioClip[] tracks;
	public int trackCount = 0;
	public float[] startTimes;
	int currentIndex = 0;
	
	float timer = 0.0f;
	
	void Update ()
	{
		timer += Time.deltaTime;
		
		if(trackCount > currentIndex
			&& timer > startTimes[currentIndex])
		{
			audio.clip = tracks[currentIndex];
			audio.Play();
			currentIndex++;	
		}
	}
}
