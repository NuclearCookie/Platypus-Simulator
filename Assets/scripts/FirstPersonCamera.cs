using UnityEngine;
using System.Collections;

public class FirstPersonCamera : MonoBehaviour {
    
    public float sensitivityX = 4.0f;
    public float sensitivityY = 4.0f;
    public float minimumY = -60f;
    public float maximumY = 60f;
    public bool flipY = false;
    public bool flipX = false;
    public float deadZoneTreshold = 0.1f;

    private float rotationY = 0.0f;
    
    // Use this for initialization
    void Start () {
        Input.gyro.enabled = true;
        Screen.showCursor = false;
    }

    /// Update is called once per frame
    void Update()
    {
        float rotationX = 0;

        float xVelocity = 0.0f;
        float yVelocity = 0.0f;

#if UNITY_STANDALONE
        xVelocity += Input.GetAxis("Mouse X");
        yVelocity += Input.GetAxis("Mouse Y");
#endif
        xVelocity += Mathf.Abs(Input.gyro.rotationRateUnbiased.y) > deadZoneTreshold ? Input.gyro.rotationRateUnbiased.y : 0;
        yVelocity += Mathf.Abs(Input.gyro.rotationRateUnbiased.x) > deadZoneTreshold ? Input.gyro.rotationRateUnbiased.x : 0;

        if (!flipX)
            rotationX = transform.localEulerAngles.y + xVelocity * sensitivityX;
        else
            rotationX = transform.localEulerAngles.y - xVelocity * sensitivityX;

        if (!flipY)
            rotationY += yVelocity * sensitivityY;
        else
            rotationY -= yVelocity * sensitivityY;

        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

        transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);

        if (Input.GetKeyUp(KeyCode.D))
        {
            Debug.Log(Input.gyro.rotationRateUnbiased);
            Debug.Log(xVelocity);
            Debug.Log(yVelocity);
        }
    }
    
    void OnApplicationFocus(bool focus){ Screen.showCursor = false; }
}
