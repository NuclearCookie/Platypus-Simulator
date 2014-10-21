using UnityEngine;
using System.Collections;

public class GlobalSettings : MonoBehaviour
{
    
	private static GlobalSettings mInstance = null;
	
	private static GlobalSettings instance
	{
		get
		{
			if( mInstance == null )
			{
				mInstance = GameObject.FindObjectOfType(typeof(GlobalSettings)) as GlobalSettings;
 
				if( mInstance == null )
				{
					mInstance = new GameObject("GlobalSettings").AddComponent<GlobalSettings>();
				}
			}
 
			return mInstance;
		}
	}
	
	
	void Awake()
	{
		if( mInstance == null )
		{
			mInstance = this as GlobalSettings;
			//instance.init();
		}
	}
	
	public bool UseOcculusRift = true;
	public bool UseMicrophone = true;
	
	public static bool GetUsingOcculusRift() { return instance.UseOcculusRift; }
	public static bool GetUsingMicrophone() { return instance.UseMicrophone; }
	public static void ToggleUsingOcculusRift() { instance.UseOcculusRift = !instance.UseOcculusRift; }
	public static void DisableUsingOcculusRift() { instance.UseOcculusRift = false; }
	public static void EnableUsingOcculusRift() { instance.UseOcculusRift = true; }
}
