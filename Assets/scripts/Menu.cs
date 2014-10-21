using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	
	public GameObject GameObjectButton;
	public string LevelName;
	public Color fadeColor = Color.white;
	public float fadeDuration = 1f;
	public float fadeDelay = 0f;
	
	private Ray ray;
	private RaycastHit hit;

	
	// Update is called once per frame
	void Update () 
	{
		/*
		if(loadingLevel.isDone && justACheck)
		{
			justACheck = false;
			Debug.Log("Finished loading next level");
		}*/
		if(Input.GetMouseButtonDown(0))
		{
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(ray,out hit))
			{
				if(hit.transform.name == GameObjectButton.transform.name)
				{
					CameraFade.StartAlphaFade( fadeColor, false, fadeDuration, fadeDelay, () => {Application.LoadLevel(LevelName); });
				}
			}
		}
	}
}
