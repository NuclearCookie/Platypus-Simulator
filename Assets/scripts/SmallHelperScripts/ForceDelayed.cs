using UnityEngine;
using System.Collections;

public class ForceDelayed : MonoBehaviour {
	
	public Vector3 force;
	public float startTime;
	public ForceMode forceMode;
	
	private float elapsedTime = 0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		elapsedTime += Time.deltaTime;
		if(elapsedTime >= startTime)
		{
			if(gameObject.GetComponent<Rigidbody>())
			{
				gameObject.GetComponent<Rigidbody>().AddForce(force,forceMode);
			}
		}
	}
}
