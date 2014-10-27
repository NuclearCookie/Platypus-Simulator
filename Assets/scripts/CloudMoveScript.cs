using UnityEngine;
using System.Collections;

public class CloudMoveScript : MonoBehaviour {

	private static float MoveSpeed = 3.0f;
	private static  Vector3 Direction = new Vector3(0,0,-1);
	
	public float MinSpeedOffset = 0.0f;
	public float MaxSpeedOffset = 0.0f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += Direction * (MoveSpeed + Random.Range(MinSpeedOffset, MaxSpeedOffset)) * Time.deltaTime;
	}
	
	void OnCollisionEnter(Collision col)
	{
		enabled = false;
	}
}
