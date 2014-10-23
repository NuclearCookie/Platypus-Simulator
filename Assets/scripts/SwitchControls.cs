using UnityEngine;
using System.Collections;

public class SwitchControls : MonoBehaviour {
	
	public bool DebugMode = true;
	
	public GameObject WarningObject;
	
	// Use this for initialization
	void Start () {
		ActivateClassicMode();
	}
	 
	// Update is called once per frame
	void Update () {
		Screen.lockCursor = true;
		
		gameObject.GetComponent<MicrophoneListener>().enabled = true;
		ActivateClassicMode();
	}

	private void ActivateClassicMode() {
		((KissController)GetComponent("KissController")).Lips = gameObject.transform.Find("DuckBeak").gameObject;
	}
}
