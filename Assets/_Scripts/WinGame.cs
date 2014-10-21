using UnityEngine;
using System.Collections;

public class WinGame : MonoBehaviour {

	float elapsedTime = 0.0f;
	public float targetTime = 250.0f;
	
	// Update is called once per frame
	void Update ()
	{
		elapsedTime += Time.deltaTime;
		if(elapsedTime >= targetTime)
		{
			Application.LoadLevel("Credits");
		}
	}
}
