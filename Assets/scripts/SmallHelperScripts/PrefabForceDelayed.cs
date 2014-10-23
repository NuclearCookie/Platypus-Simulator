using UnityEngine;
using System.Collections;

public class PrefabForceDelayed : MonoBehaviour {
	
	AudioSpawner audioSpawner;
	public AudioClip spawnClip;
	
	public Transform prefab;
	public Vector3 force;
	public float startTime;
	public ForceMode forceMode;
	
	private float elapsedTime = 0f;
	private Transform objectToUse;
	
	void Start ()
	{
		audioSpawner = gameObject.AddComponent<AudioSpawner>();
	}
	// Update is called once per frame
	void Update ()
	{
		elapsedTime += Time.deltaTime;
		if(elapsedTime >= startTime)
		{
			audioSpawner.Play(spawnClip, transform.position, false, 1.0f, 1.0f);
			objectToUse = (Transform)Instantiate(prefab, gameObject.transform.position, gameObject.transform.rotation);
			objectToUse.GetComponent<Rigidbody>().AddForce(force,forceMode);
			this.enabled = false;
		}
	}
}
