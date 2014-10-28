using UnityEngine;
using System.Collections;

public class CameraCulling : MonoBehaviour {

    public float[] DistancesPerLayer = new float[32];
    // Use this for initialization
    void Start () {
        gameObject.GetComponent<Camera>().layerCullDistances = DistancesPerLayer;
    }
}
