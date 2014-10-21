using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour {
	
	float speed = 10.0f;
	
	void Start ()
	{
		transform.GetComponent<TextMesh>().text =
			"Thank you for kissing! <3 \n" +
			"\n" +
			"You kissed " + PlayerPrefs.GetInt("PPP_Score", 0) + " animals. \n" +
			"\n" + 
			"\n" + 
			"==Lover==\n" + 
			" Glen De Cauwsemaecker\n" +
			"\n" + 
			"==Cook==\n" +
			" Pieter Vantorre\n" + 
			"\n" + 
			"==Visioner==\n" +
			" Samuli Jääskeläinen\n" +
			"\n" +
			"==Not An Artist==\n" + 
			" Tommy Tan Sze Yew\n" +
			"\n" +
			"\n" + 
			"\n" +
			"Special thanks\n" +
			"Kajaani University of\nApplied Sciences\n" + 
			"Kajak Games\n" + 
			"OculusVR\n" + 
			"Pizzeria Lori\n" +
			"Indie Speed Run 2013\n" +
			"\n";
			
	}
	
	void Update()
	{
		Vector3 newPos = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);
		transform.localPosition = newPos;
		
		if(transform.localPosition.y > 230.0f)
		{
			Application.LoadLevel(0);	
		}
	}
}
