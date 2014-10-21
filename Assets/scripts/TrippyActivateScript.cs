using UnityEngine;
using System.Collections;

public class TrippyActivateScript : MonoBehaviour {
	
	public GameObject Player;
	
	void Update()	
	{
		if(Player.transform.position.z > transform.position.z)
		{
			Player.GetComponent<SpecialShaders>().SetTrippyEnabled(true,0.2f,true);
			Destroy(this);
		}
	}
}
