using UnityEngine;
using System.Collections;

public class Lerp : MonoBehaviour {
	
	public Vector3 endPos;
	public float speed;
	private Vector3 startPos;
	private float startTime;
	private float journeyLength;
	
	// Use this for initialization
	void Start () {
		startTime = Time.time;
		startPos = gameObject.transform.position;
		journeyLength = Vector3.Distance(startPos, endPos);
	}
	
	// Update is called once per frame
	void Update () {
		
		float distCovered = (Time.time - startTime) * speed;
    	float fracJourney = distCovered / journeyLength;
		gameObject.transform.position = Vector3.Lerp(startPos, endPos, fracJourney);
		
	}
}
