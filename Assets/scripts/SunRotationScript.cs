using UnityEngine;
using System.Collections;

public class SunRotationScript : MonoBehaviour {
	
	[SerializeField]
	private GameObject SkyDome;
	
	public float DayTimeSpeed = 1.0f;
	public float MinSunIntensity = 0.35f;
	public float MaxSunIntensity = 1.2f;
	public float MinSunHeight = 10.0f;
	public float MaxSunHeight = 22.0f;
	
	private float RealAngles;
	
	public float SkyRotationSpeed;
	
	enum DayState {
		Sunny,
		Rainy
	};
	
	private DayState State;
	
	// Use this for initialization
	void Start () {
		RealAngles = transform.localEulerAngles.y;
		State = DayState.Sunny;
	}
	
	// Update is called once per frame
	void Update () {
		UpdateDayTime();
		switch(State)
		{
		case DayState.Rainy:
			UpdateRainyState();
			break;
		case DayState.Sunny:
			UpdateSunnyState();
			break;
		}
		SkyDome.transform.Rotate(SkyDome.transform.up, Time.deltaTime * SkyRotationSpeed);
	}
	
	private void UpdateDayTime() {
		transform.Rotate(transform.up, Time.deltaTime * DayTimeSpeed);
		RealAngles += Time.deltaTime * DayTimeSpeed;
		// PiTimesTwo 
		float lerpValue = (RealAngles % 360.0f) / 360.0f;
		lerpValue *= 2.0f;
		lerpValue -= (lerpValue % 1.0f) * 2.0f;
		lerpValue = Mathf.Abs(lerpValue);
		GetComponent<Light>().intensity = Mathf.Lerp(MinSunIntensity, MaxSunIntensity, lerpValue);
		Vector3 pos = transform.position;
		pos.y = Mathf.Lerp(MinSunHeight, MaxSunHeight, lerpValue);
		transform.position = pos;
	}
	
	private void UpdateRainyState() {
		
	}
	
	private void UpdateSunnyState() {
		
	}
}
