using UnityEngine;
using System.Collections;

public class SleepPhysics : MonoBehaviour
{
	void Start ()
	{
		transform.rigidbody.Sleep();
		transform.rigidbody.useGravity = false;
	}
	
	void OnCollisionEnter(Collision col)
	{
		transform.rigidbody.WakeUp();
		transform.rigidbody.useGravity = true;
	}
}
