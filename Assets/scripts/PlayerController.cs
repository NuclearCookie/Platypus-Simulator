using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float PlayerSpeed = 2.0f;
	public float WaveSpeed = 1.0f;
	public float DefaultHeight = 1.0f;
	public float HeightOffset = 10.0f;

	private float HeightAngle = 0;
	
	private float ForwardSpeed = 1.0f;
	
	public bool EnableForwardDebug = false;

	// Use this for initialization
	void Start () {
		PlayerPrefs.GetInt("PPP_Score", 0);
		PlayerPrefs.SetInt("PPP_Score", 0);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 playerPos = transform.position;
		
		if(EnableForwardDebug)
		{
			playerPos.z += PlayerSpeed * Time.deltaTime * ForwardSpeed;
		}
		else
		{
			playerPos.z += PlayerSpeed * Time.deltaTime;
		}
		playerPos.y = DefaultHeight;
		HeightAngle += Time.deltaTime;
		playerPos.y += Mathf.Cos(HeightAngle * WaveSpeed) * HeightOffset;

		transform.position = playerPos;
		
		if(EnableForwardDebug)
		{
			for(int i = 1 ; i < 9 ; ++i)
			{
				if(Input.GetKeyDown(i.ToString()))
				{
					ForwardSpeed = i + Mathf.Pow(2,i-1) - 1;
				}	
			}
		}
	}
}
