using UnityEngine;
using System.Collections;

public class KissController : MonoBehaviour {

    [SerializeField]
    private GameObject KissAttackPrefab;

    public GameObject Lips;

    [SerializeField]
    private GameObject CameraObject;

    public float SpawnOffset = 10.0f;

    private MicrophoneListener MicrophoneScript;

	// Use this for initialization
	void Start () {
        MicrophoneScript = gameObject.GetComponent<MicrophoneListener>();
	}
	
	// Update is called once per frame
	void Update () {
        if (MicrophoneScript.CanKiss() || Input.GetButtonDown("Kiss"))
        {
            Vector3 kissAttackPosition = Lips.transform.position;
            kissAttackPosition += SpawnOffset * Lips.transform.forward;

            GameObject kissAttack = (GameObject)Instantiate(KissAttackPrefab, kissAttackPosition, Quaternion.identity);

            KissAttackScript kissScript = kissAttack.GetComponent<KissAttackScript>();
            kissScript.Direction = kissAttackPosition - Lips.transform.position;
            kissScript.Direction.Normalize();
            kissScript.CameraObject = CameraObject;
        }
	}
}
