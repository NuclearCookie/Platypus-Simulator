using UnityEngine;
using System.Collections;

public class SwitchControls : MonoBehaviour {
	
	public string nameOfOcculusController = "OVRCameraController";
	public string nameOfNormalController = "CameraController";
	
	private bool AutomaticUpdate = true;
	
	public bool DebugMode = true;
	
	public GameObject WarningObject;
	
	private SpecialShaders SpecialShadersController;
	
	// Use this for initialization
	void Start () {
		SpecialShadersController = transform.gameObject.GetComponent<SpecialShaders>();
		SetCorrectMode();
		SpecialShadersController.DisableSpecialEffects();
	}
	 
	// Update is called once per frame
	void Update () {
		Screen.lockCursor = true;
		
		gameObject.GetComponent<MicrophoneListener>().enabled = true;
		if(Input.GetButtonDown("Oculus")) {
			SpecialShadersController.DisableSpecialEffects();
			GlobalSettings.ToggleUsingOcculusRift();
			AutomaticUpdate = false;
		}
		else if(AutomaticUpdate)
		{
			GlobalSettings.EnableUsingOcculusRift();
		}
		SetCorrectMode();
	}
	
	private void SetCorrectMode() {
		if(GlobalSettings.GetUsingOcculusRift()
			&& !DebugMode)
		{
			GlobalSettings.DisableUsingOcculusRift();
			WarningObject.GetComponent<WarningScript>().ActivateWarning();
		}
		if(GlobalSettings.GetUsingOcculusRift())
		{
			ActivateOcculusMode();
			SpecialShadersController.SetOculusMode();
			GameObject OVRObject = gameObject.transform.Find("OVRCameraController").gameObject;
			bool fpsCameraEnabled = false;
			OVRObject.GetComponent<OVRDevice>().enabled = !fpsCameraEnabled;
			OVRObject.GetComponent<OVRCameraController>().enabled = !fpsCameraEnabled;
			GameObject OVRLeft = gameObject.transform.Find("OVRCameraController/CameraLeft").gameObject;
			OVRLeft.GetComponent<FirstPersonCamera>().enabled = fpsCameraEnabled;
			OVRLeft.GetComponent<OVRCamera>().enabled = !fpsCameraEnabled;
			GameObject OVRRight = gameObject.transform.Find("OVRCameraController/CameraRight").gameObject;
			OVRRight.GetComponent<FirstPersonCamera>().enabled = fpsCameraEnabled;
			OVRRight.GetComponent<OVRCamera>().enabled = !fpsCameraEnabled;
		}
		else
		{
			ActivateClassicMode();
			SpecialShadersController.SetClassicMode();
		}
	}
	
	private void ActivateOcculusMode() {
		gameObject.transform.FindChild(nameOfNormalController).gameObject.SetActive(false);
		gameObject.transform.FindChild(nameOfOcculusController).gameObject.SetActive(true);
		((KissController)GetComponent("KissController")).Lips = gameObject.transform.Find("OVRCameraController/CameraLeft/DuckBeak").gameObject;
	}
	
	private void ActivateClassicMode() {
		gameObject.transform.FindChild(nameOfOcculusController).gameObject.SetActive(false);
		gameObject.transform.FindChild(nameOfNormalController).gameObject.SetActive(true);
		((KissController)GetComponent("KissController")).Lips = gameObject.transform.Find("CameraController/DuckBeak").gameObject;
	}
}
