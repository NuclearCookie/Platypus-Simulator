using UnityEngine;
using System.Collections;

public class FirstPersonCamera : MonoBehaviour {
	
	public float sensitivityX = 4.0f;
	public float sensitivityY = 4.0f;
	public float minimumY = -60f;
	public float maximumY = 60f;
	public bool flipY = false;
	public bool flipX = false;
	
	float rotationY = 0f;
	// Use this for initialization
	void Start () {
		Screen.showCursor = false;
	}
	
	
	/// Update is called once per frame
	void Update ()
	{		
		float rotationX = 0;
		if(!flipX)
			rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
		else
			rotationX = transform.localEulerAngles.y - Input.GetAxis("Mouse X") * sensitivityX;
		
		if(!flipY)
			rotationY  += Input.GetAxis("Mouse Y") * sensitivityY;
		else
			rotationY  -= Input.GetAxis("Mouse Y") * sensitivityY;
		
		rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
		
		transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
	}
	
	void OnApplicationFocus(bool focus){ Screen.showCursor = false; }
}
