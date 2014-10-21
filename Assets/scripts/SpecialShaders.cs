using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpecialShaders : MonoBehaviour {
	private TrippyPafKous TrippyShader_A = null;
	private TrippyPafKous TrippyShader_B = null;
	private MagicMushRoomShader MagicShader_A = null;
	private MagicMushRoomShader MagicShader_B = null;
	
	private float TrippySquigleSize = 0.075f;
	private float TrippySquigleSpeed = 0.075f;
	private float SquigleAmountX = 0.2f;
	private float SquigleAmountY = 0.05f;
	
	private bool TrippyEnabled = false;
	private bool MagicEnabled = false;
	
	private float CurrentTrippyTime = 0;
	private float MaxTrippyTime = 0;
	private float CurrentMagicTime = 0;
	private float MaxMagicTime = 0;
	
	public struct ListInfo 
	{
		public bool Enabled;
		public float WaitTime;
		public bool Reset;
	}
	
	private List<ListInfo> MagicWaitList;
	private List<ListInfo> TrippyWaitList;
	
	void Start()
	{
		MagicWaitList = new List<ListInfo>();
		TrippyWaitList = new List<ListInfo>();
	}
	
	void Update()
	{
		if(TrippyWaitList.Count > 0)
		{
			if(CurrentTrippyTime < TrippyWaitList[0].WaitTime)
			{
				CurrentTrippyTime += Time.deltaTime;
			}
			else
			{
				SetTrippyDelayedEnabled(TrippyWaitList[0].Enabled);
				if(TrippyWaitList[0].Reset)
				{
					CurrentTrippyTime = 0;	
				}
				TrippyWaitList.RemoveAt(0);
			}
		}
		else
		{
			CurrentTrippyTime = 0;	
		}
		if(MagicWaitList.Count > 0)
		{
			if(CurrentMagicTime < MagicWaitList[0].WaitTime)
			{
				CurrentMagicTime += Time.deltaTime;
			}
			else
			{
				SetMagicDelayedEnabled(MagicWaitList[0].Enabled);
				if(MagicWaitList[0].Reset)
				{
					CurrentMagicTime = 0;	
				}
				MagicWaitList.RemoveAt(0);
			}
		}
		else
		{
			CurrentMagicTime = 0;	
		}
	}
	
	public void SetTrippyEnabled(bool enabled, float WaitTime, bool reset)
	{
		ListInfo info;
		info.Enabled = enabled;
		info.WaitTime = WaitTime;
		info.Reset = reset;
		if(TrippyWaitList == null)
		{
			TrippyWaitList = new List<ListInfo>();
		}
		TrippyWaitList.Add(info);
	}
	
	public void SetMagicEnabled(bool enabled, float WaitTime, bool reset)
	{
		ListInfo info;
		info.Enabled = enabled;
		info.WaitTime = WaitTime;
		info.Reset = reset;
		if(MagicWaitList == null)
		{
			MagicWaitList = new List<ListInfo>();
		}
		MagicWaitList.Add(info);
	}
	
	private void SetTrippyDelayedEnabled(bool enabled)
	{
		if(enabled)
		{
			TrippyShader_A.squigleSize = TrippySquigleSize;	
			TrippyShader_A.squigleSpeed = TrippySquigleSpeed;
			TrippyShader_A.squigleAmountX = SquigleAmountX;
			TrippyShader_A.squigleAmountY = SquigleAmountY;
			if(TrippyShader_B != null)
			{
				TrippyShader_B.squigleSize = TrippySquigleSize;	
				TrippyShader_B.squigleSpeed = TrippySquigleSpeed;
				TrippyShader_B.squigleAmountX = SquigleAmountX;
				TrippyShader_B.squigleAmountY = SquigleAmountY;	
			}
		}
		else
		{
			TrippyShader_A.squigleSize = 0;	
			TrippyShader_A.squigleSpeed = 0;
			TrippyShader_A.squigleAmountX = 0;
			TrippyShader_A.squigleAmountY = 0;
			if(TrippyShader_B != null)
			{
				TrippyShader_B.squigleSize = 0;	
				TrippyShader_B.squigleSpeed = 0;
				TrippyShader_B.squigleAmountX = 0;
				TrippyShader_B.squigleAmountY = 0;	
			}
		}
	}
	
	private void SetMagicDelayedEnabled(bool enabled)
	{
		MagicShader_A.enabled = enabled ? 1.0f : 0.0f;
		if(TrippyShader_B != null)
		{
			MagicShader_B.enabled = enabled ? 1.0f : 0.0f;
		}
	}
	
	public void DisableSpecialEffects()
	{
		SetTrippyEnabled(false, 0, true);
		SetMagicEnabled(false, 0, true);	
	}
	
	public void SetOculusMode()
	{
		TrippyShader_A = gameObject.transform.Find("OVRCameraController/CameraLeft").gameObject.GetComponent<TrippyPafKous>();
		TrippyShader_B = gameObject.transform.Find("OVRCameraController/CameraRight").gameObject.GetComponent<TrippyPafKous>();
		MagicShader_A = gameObject.transform.Find("OVRCameraController/CameraLeft").gameObject.GetComponent<MagicMushRoomShader>();
		MagicShader_B = gameObject.transform.Find("OVRCameraController/CameraRight").gameObject.GetComponent<MagicMushRoomShader>();
	}
	
	public void SetClassicMode()
	{
		TrippyShader_A = gameObject.transform.Find("CameraController").gameObject.GetComponent<TrippyPafKous>();
		TrippyShader_B = null;
		MagicShader_A = gameObject.transform.Find("CameraController").gameObject.GetComponent<MagicMushRoomShader>();
		MagicShader_B = null;
	}
}
