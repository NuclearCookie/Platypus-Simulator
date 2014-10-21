using UnityEngine;
using System.Collections;

public class RandomColor : MonoBehaviour
{

	void Start ()
	{
		float r = Random.Range(0.0f, 1.0f);
		float g = Random.Range(0.0f, 1.0f);
		float b = Random.Range(0.0f, 1.0f);
		
		Color newColor = new Color(r, g, b);
		renderer.material.color = newColor;
		this.enabled = false;
	}
}
