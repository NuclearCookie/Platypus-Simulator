using UnityEngine;
using System.Collections;

public class TimeDebug : MonoBehaviour {
	
	float curTime = 0.0f;
	
	// Update is called once per frame
	void Update ()
	{
		curTime += Time.deltaTime;
		//Debug.Log("Current time: " + (int)curTime);
	}
}
