using UnityEngine;
using System.Collections;

public class MoveDelayed : MonoBehaviour {
	
	public float speed;
	public Vector3 direction;
	public float startTime;
	
	private float elapsedTime = 0;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		elapsedTime += Time.deltaTime;
		
		if(elapsedTime >= startTime)
		{
			gameObject.transform.position += direction.normalized * speed * Time.deltaTime;
		}
	}
}
