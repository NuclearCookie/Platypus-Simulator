using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {
	
	public bool worldAxis;
	public float speed;
	public Vector3 axis;
	public bool rotateAroundVector3;
	public Vector3 rotationAxis;
	
	// Update is called once per frame
	void Update ()
	{
		if(!rotateAroundVector3)
		{
			if(!worldAxis)
				gameObject.transform.Rotate(axis * speed * Time.deltaTime);
			else
				gameObject.transform.Rotate(axis * speed * Time.deltaTime, Space.World);
		}
		else
		{
			if(!worldAxis)
			{
				gameObject.transform.Rotate(rotationAxis,speed * Time.deltaTime);
			}
				
			else
				gameObject.transform.Rotate(rotationAxis, speed * Time.deltaTime);
		}
	}
	
	void OnCollisionEnter(Collision col)
	{
		this.enabled = false;
	}

}
