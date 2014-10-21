using UnityEngine;
using System.Collections;

public class LerpRandomColors : MonoBehaviour
{
	Color color1, color2;
	public float speed = 1.0f;
	
	void Start ()
	{
		float r1 = Random.Range(0.0f, 1.0f);
		float g1 = Random.Range(0.0f, 1.0f);
		float b1 = Random.Range(0.0f, 1.0f);
		color1 = new Color(r1, g1, b1);
		renderer.material.color = color1;
		
		float r2 = Random.Range(0.0f, 1.0f);
		float g2 = Random.Range(0.0f, 1.0f);
		float b2 = Random.Range(0.0f, 1.0f);
		color2 = new Color(r2, g2, b2);
	}
	
	void Update()
	{
		float lerp = Mathf.PingPong(Time.time, speed) / speed;
        renderer.material.color = Color.Lerp(color1, color2, lerp);	
	}
}
