using UnityEngine;
using System.Collections;

public class SelfDestructScript : MonoBehaviour {
    public float TimeValue = 2.0f;

	// Use this for initialization
	void Start () {
        StartCoroutine("KillMe", TimeValue);
	}

    IEnumerator KillMe(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);
    }
}
