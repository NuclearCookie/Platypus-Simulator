using UnityEngine;
using System.Collections;

public class SwitchControls : MonoBehaviour {
	
	private bool AutomaticUpdate = true;
	
	public bool DebugMode = true;
	
	public GameObject WarningObject;
	
	private SpecialShaders SpecialShadersController;
	
	// Use this for initialization
	void Start () {
		SpecialShadersController = transform.gameObject.GetComponent<SpecialShaders>();
		ActivateClassicMode();
		SpecialShadersController.DisableSpecialEffects();
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
