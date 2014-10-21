using UnityEngine;
using System.Collections;

public class RotateScript : MonoBehaviour {
	
	public bool worldAxis;
	public float speed;
	public Vector3 RotateAroundWhatAxis;
	public bool rotateAroundVector3;
	public Vector3 rotationAxis;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(!rotateAroundVector3)
		{
			if(!worldAxis)
				gameObject.transform.Rotate(RotateAroundWhatAxis * speed * Time.deltaTime);
			else
				gameObject.transform.Rotate(RotateAroundWhatAxis * speed * Time.deltaTime, Space.World);
		}
		else
		{
			if(!worldAxis)
				gameObject.transform.Rotate(rotationAxis,speed * Time.deltaTime);
				
			else
				gameObject.transform.Rotate(rotationAxis, speed * Time.deltaTime, Space.World);
		}
	}

}
