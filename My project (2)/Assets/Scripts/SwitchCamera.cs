using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{

    Camera mainCamera;
    public Camera secondaryCamera;



    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        mainCamera.enabled = true;

        secondaryCamera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (mainCamera.enabled)
            {
                secondaryCamera.enabled = true;

                mainCamera.enabled = false;
            }
            else if (!mainCamera.enabled)
            {
                secondaryCamera.enabled = false;
                mainCamera.enabled = true;
            }
        }
    }
}
