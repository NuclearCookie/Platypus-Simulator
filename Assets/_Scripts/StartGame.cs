using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

    int inputs = 0;

    void Start()
    {
        Screen.orientation = ScreenOrientation.Landscape;
    }

    // Update is called once per frame
    void Update ()
    {
        if(Input.anyKey
            && !Input.GetButton("Oculus"))
        {
            inputs++;

            if(inputs >= 2)
            {
                int nextLevel = Application.loadedLevel + 1;
                Application.LoadLevel(nextLevel);
            }
        }
    }
}
