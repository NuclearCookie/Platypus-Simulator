using UnityEngine;
using System.Collections;

public class BalloonDeadScript : MonoBehaviour {
	public GameObject BalloonPrefab;
	
	public AudioClip yell;
	AudioSpawner audioSpawner;
	
	public int BalloonAmount = 3;
	public float OffsetRange;
	public Vector3 SpawnOffset = new Vector3(0, 4, 0);
	
	private int CurrentHealth = 0;
	private int MaxCurrentHealth = 1;
	
	private static int MaximumScore = 0;
	
	void Start ()
	{
		audioSpawner = gameObject.AddComponent<AudioSpawner>();
		++MaximumScore;
		CurrentHealth = MaxCurrentHealth;
		PlayerPrefs.SetInt("PPP_MaxScore", MaximumScore);
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.transform.tag == "Kissie")
		{
			--CurrentHealth;
			if(CurrentHealth < 1)
			{
				PlayerPrefs.SetInt("PPP_Score", PlayerPrefs.GetInt("PPP_Score") + 1);
				GetComponent<MeshRenderer>().enabled = false;
				GetComponent<MeshCollider>().enabled = false;
				//Debug.Log ("Killed " + PlayerPrefs.GetInt("PPP_Score") + " / " + MaximumScore);
				for (int i = 0; i < BalloonAmount; ++i)
				{
					StartCoroutine("SpawnBalloon", i * 0.02f);
				}
				StartCoroutine("KillMe", BalloonAmount * 0.5f);	
			}
		}
	}

	IEnumerator SpawnBalloon(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		audioSpawner.Play(yell, transform.position, false, 1.0f, 1.0f);
		Vector3 pos = transform.position + SpawnOffset;
		Vector3 size = GetComponent<MeshRenderer>().bounds.size;
		pos.x += Random.Range(size.x * -0.35f, size.x * 0.35f);
		pos.y += Random.Range(size.y * -0.35f, size.y * 0.35f);
		pos.z += Random.Range(size.z * -0.35f, size.z * 0.35f);
		Instantiate(PrefabManager.Instance.BalloonPrefab, pos, BalloonPrefab.transform.rotation);
	}

	IEnumerator KillMe(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		Destroy(gameObject);
	}
}
