using UnityEngine;
using System.Collections;

public class HeliumScript : MonoBehaviour
{
	public Vector3 helium = new Vector3(0.0f, 0.28f, 0.0f);
	
	void FixedUpdate ()
	{
		rigidbody.AddForce(helium, ForceMode.VelocityChange);
	}
}
