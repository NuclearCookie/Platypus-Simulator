using UnityEngine;
using System.Collections;

public class KillParticle : MonoBehaviour {
	
	public ParticleSystem systemToDestroy;
	// Use this for initialization
	void Start () {
		if(systemToDestroy.loop == true)
		{
			Debug.LogWarning("The particle won't stop because it's looping!");	
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(systemToDestroy.isStopped && !systemToDestroy.loop)
		{
			Destroy (systemToDestroy);	
			Destroy (gameObject);
		}
	}
}
