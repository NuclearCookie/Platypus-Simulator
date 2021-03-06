﻿using UnityEngine;
using System.Collections;

public class KissController : MonoBehaviour {

	public GameObject KissAttackPrefab;

	public GameObject Lips;

	public GameObject CameraObject;

	public float SpawnOffset = 10.0f;

	private MicrophoneListener MicrophoneScript;

	// Use this for initialization
	void Start () {
		MicrophoneScript = gameObject.GetComponent<MicrophoneListener>();
	}
	
	// Update is called once per frame
	void Update () {
		if (MicrophoneScript.CanKiss() || Input.GetButtonDown("Kiss"))
		{
			Vector3 kissAttackPosition = Lips.transform.position;
			kissAttackPosition += SpawnOffset * Lips.transform.forward;

			GameObject kissAttack = Instantiate(KissAttackPrefab, kissAttackPosition, Quaternion.identity) as GameObject;

			KissAttackScript kissScript = kissAttack.GetComponent<KissAttackScript>();
			kissScript.Direction = kissAttackPosition - Lips.transform.position;
			kissScript.Direction.Normalize();
			kissScript.CameraObject = CameraObject;
		}
	}
}
