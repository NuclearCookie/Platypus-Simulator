using UnityEngine;
using System.Collections;

public class BallonMultiplyScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter(Collision col)
    {
        if (col.transform.tag == "Kissie")
        {
			col.transform.tag = "Untagged";
			for (int i = 0; i < 2; ++i)
            {
				Vector3 pos = transform.position;
		        Vector3 size = GetComponent<MeshRenderer>().bounds.size;
		        pos.x += Random.Range(size.x * -0.35f, size.x * 0.35f);
		        pos.y += Random.Range(size.y * -0.35f, size.y * 0.35f);
		        pos.z += Random.Range(size.z * -0.35f, size.z * 0.35f);
		        Instantiate(gameObject, pos, gameObject.transform.rotation);
            }
			Destroy (gameObject);
		}
	}
}
