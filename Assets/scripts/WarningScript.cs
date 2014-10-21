using UnityEngine;
using System.Collections;

public class WarningScript : MonoBehaviour {
	float OcculusWarningTimer = 3.0f;
	
	public void ActivateWarning()
	{
		OcculusWarningTimer = 0.0f;
		renderer.enabled = true;	
	}
	
	// Update is called once per frame
	void Update () {
		if(OcculusWarningTimer < 3.0f)
		{
			OcculusWarningTimer += Time.deltaTime;	
		}
		else
		{
			renderer.enabled = false;	
		}
	}
}
