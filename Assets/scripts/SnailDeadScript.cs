using UnityEngine;
using System.Collections;

public class SnailDeadScript : MonoBehaviour {
	
	private GameObject Controller;
	private SpecialShaders SpecialShadersController;
	// Use this for initialization
	void Start () {
		Controller = GameObject.FindGameObjectWithTag("CONTROLLER");
		SpecialShadersController = Controller.GetComponent<SpecialShaders>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter(Collision col)
    {
        if (col.transform.tag == "Kissie")
        {
			SpecialShadersController.SetMagicEnabled(true, 0, false);
			SpecialShadersController.SetMagicEnabled(false, 5, true);
		}	
	}
}
