using UnityEngine;
using System.Collections;

public class QuitScript : MonoBehaviour {
	
	public bool backToMenu = false;
	
	void Update ()
	{
		if(Input.GetButton("Quit"))
		{
			if(backToMenu)
			{
				Application.LoadLevel(0);
			}
			else
			{
				Application.Quit();	
			}
		}
	}
}
