using UnityEngine;
using System.Collections;

public class KissAttackScript : MonoBehaviour
{
	AudioSpawner audioSpawner = new AudioSpawner();
	public AudioClip hitClip;//, kissClip;
	
    public GameObject CameraObject;
    public Vector3 Direction;
    [SerializeField]
    private float KissSpeed;
    [SerializeField]
    private float MaximumTime;
    private float CurrentTime = 0.0f;
	
	void Awake()
	{
		//audioSpawner.Play(kissClip, transform.position, false, 0.2f, 1.0f);	
	}
	
	// Update is called once per frame
	void Update ()
	{
        CurrentTime += Time.deltaTime;

        transform.position += Direction * Time.deltaTime * KissSpeed;

        transform.localScale *= 1.01f;

        if (CurrentTime > MaximumTime)
		{
            Destroy(gameObject);
        }

        Color color = transform.renderer.material.color;
        color.a = 1.0f - CurrentTime / MaximumTime;
        transform.renderer.material.color = color;

        Vector3 direction = transform.position - CameraObject.transform.position;
        direction.Normalize();

        transform.rotation = Quaternion.LookRotation(direction);
	}
	
	void OnCollisionEnter(Collision col)
	{
		Debug.Log(col.transform.tag);
		
		if(col.transform.tag == "KissMe")
		{
			audioSpawner.Play(hitClip, transform.position, false, 0.2f, 1.0f);
		}
	}
}
